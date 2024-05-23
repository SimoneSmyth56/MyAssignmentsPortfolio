using AzureBlobStorageAssessment;
using Serilog;


internal class Program
{
    private static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        StorageHandler storageHandler = new StorageHandler();
        while (true)
        {
                Console.WriteLine("Menu Options");
                Console.WriteLine("1.Upload Blob");
                Console.WriteLine("2.List Blobs");
                Console.WriteLine("3.Download Blob");
                Console.WriteLine("4.Delete Blob");
                Console.WriteLine("0.Exit program");
                Console.WriteLine("");
                int listOption = Convert.ToInt32(Console.ReadLine());
                switch (listOption)
                {
                    //Upload Blob
                    case 1:
                    Console.WriteLine("Please add the file path you would like to upload files from:");

                    // Remove double quotes from the input.
                    // The null - conditional operator (?) ensures that the Replace method is
                    // only called if the result of Console.ReadLine() is not null.
                    // If Console.ReadLine() returns null, the entire expression evaluates to null,
                    // and the Replace method is not executed.This prevents a NullReferenceException
                    // from occurring.
                    var directoryPath = Console.ReadLine()?.Replace("\"", "") + "\\"; 



                        // Get the directory of the files in the local folder
                        DirectoryInfo place = new DirectoryInfo(directoryPath);

                        // Using GetFiles() method to get list of all the files
                        FileInfo[] Files = place.GetFiles();
                        Console.WriteLine("Files currently in the folder are:");
                        Console.WriteLine();

                        // Display the file names
                        foreach (FileInfo i in Files)
                        {
                            Console.WriteLine("File Name - {0}", i.Name);
                        }
                        Console.WriteLine();

                        Console.WriteLine("Which file do you want to upload:");
                        string? fileUploadName = Console.ReadLine();
                        var isUploaded = storageHandler.UploadBlob(directoryPath,fileUploadName);
                        break;


                    //List Blobs
                    case 2:
                        List<string> blobNames = await storageHandler.ListBlobs();

                        Console.WriteLine("List of Blobs:");
                        foreach (var blobName in blobNames)
                        {
                            Console.WriteLine(blobName);
                        }
                        break;

                    //Download Blob
                    case 3:
                    Console.WriteLine("Please add the file path you would like to download files to:");
                    var downloadPath = Console.ReadLine()?.Replace("\"", "") + "\\";



                    Console.WriteLine("Which file do you want to download :");
                        string? fileDownloadName = Console.ReadLine();

                    var isDownloaded = storageHandler.DownloadBlob(downloadPath, fileDownloadName);
                        break;

                    //Delete Blob
                    case 4:
                        Console.WriteLine("Which file do you want to delete:");
                        string? fileName = Console.ReadLine();
                        var isDeleted = storageHandler.DeleteBlob(fileName);

                        Console.WriteLine($"The file is deleted: {isDeleted}");
                        break;

                    //End Program by pressing 0
                    case 0:
                    Console.WriteLine("The program is now ending");
                        Environment.Exit(0);
                        break;

                    //Error message will appear if user enters an invalid option
                    default:
                        Console.WriteLine("Please enter a valid option from the list (0 - 4)");
                        break;
                }
            Log.CloseAndFlush();
        }
    }
    }
