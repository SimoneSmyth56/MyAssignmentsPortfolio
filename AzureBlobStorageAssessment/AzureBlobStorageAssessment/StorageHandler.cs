using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Serilog;
using File = System.IO.File;

namespace AzureBlobStorageAssessment
{
    public class StorageHandler : IStorageHandler
    {
        private string connectionString = "DefaultEndpointsProtocol=https;AccountName=sld521blobstorage;AccountKey=Z6a17QYPD6OgHqqdsmhdlS7wC9lk6PLRWoVqPdznmt1Dhyh2R5Cqoap3yiznOAHjluTFNXYdkC8k+AStM/Tp4g==;EndpointSuffix=core.windows.net";
        private string containerName = "sld521container";

        public bool UploadBlob(string filePath, string fileToUpload)
        {
            try
            {
                var blobServiceClient = new BlobServiceClient(connectionString);

                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                BlobClient blobClient = containerClient.GetBlobClient(fileToUpload);

                using (FileStream fileStream = File.OpenRead(filePath + fileToUpload))
                {
                    blobClient.Upload(fileStream, true);
                }

                if (!blobClient.Exists())
                {
                    Console.WriteLine($"The file name {fileToUpload} does not exists");
                    return false;
                }

                Log.Information($"Uploaded blob: {fileToUpload}");
                return true;

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while uploading blob");
                return false;
            }
        }

        public async Task<List<string>> ListBlobs()
        {
            List<string> blobNames = new List<string>();

            try
            {
                var blobServiceClient = new BlobServiceClient(connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
                {
                    blobNames.Add(blobItem.Name);
                }
                Log.Information("Listed blobs successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while listing blobs");

            }

            return blobNames;
        }

        public bool DownloadBlob(string filePath, string blobName)
        {
            try
            {
                var blobServiceClient = new BlobServiceClient(connectionString);

                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                if (!blobClient.Exists())
                {
                    Console.WriteLine($"Blob '{blobName}' does not exist in the container.");
                    return false;
                }

                BlobDownloadInfo download = blobClient.Download();

                string fullPath = Path.Combine(filePath, blobName);
                if (File.Exists(fullPath))
                {
                    Console.WriteLine($"File '{fullPath}' already exists. Do you want to overwrite it? (Y/N)");
                    string? response = Console.ReadLine()?.Trim().ToUpper();
                    if (response != "Y")
                    {
                        Console.WriteLine("Download cancelled.");
                        return false;
                    }
                }

                // Save the blob content to a file
                using (FileStream file = File.OpenWrite(filePath + blobName))
                {
                    download.Content.CopyTo(file);
                }
                Log.Information($"Downloaded blob: {blobName}");
                return true;


            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error occurred while downloading blob: {blobName}");
                return false;
            }
        }


        public bool DeleteBlob(string blobName)
        {
            try
            {
                var blobServiceClient = new BlobServiceClient(connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                var isDeleted = containerClient.DeleteBlob(blobName);
                if (isDeleted.IsError != false)
                {
                    throw new FileNotFoundException($"File with name {blobName} is not found", blobName);
                }
                Log.Information($"Deleted blob: {blobName}");
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error occurred while deleting blob: {blobName}");
                return false;
            }
        }

        }

    }
