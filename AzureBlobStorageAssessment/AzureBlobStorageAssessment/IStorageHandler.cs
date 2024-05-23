namespace AzureBlobStorageAssessment
{
    public interface IStorageHandler
    {
        bool UploadBlob(string filePath, string fileToUpload);
        Task<List<string>> ListBlobs();
        bool DownloadBlob(string filePath, string blobName);
        bool DeleteBlob(string blobName);
    }
}
