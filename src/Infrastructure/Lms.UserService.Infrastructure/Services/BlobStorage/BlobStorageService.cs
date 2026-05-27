using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace Lms.UserService.Infrastructure.Services.BlobStorage;

public class BlobStorageService
{
    private readonly string _connectionString;
    private readonly string _containerName;

    public BlobStorageService(IConfiguration configuration)
    {
        _connectionString =
            configuration["AzureBlobStorage:ConnectionString"]!;

        _containerName =
            configuration["AzureBlobStorage:ContainerName"]!;
    }

    public async Task<string> UploadFileAsync(
    Stream stream,
    string fileName)
    {
        var blobContainerClient =
            new BlobContainerClient(
                _connectionString,
                _containerName
            );

        await blobContainerClient.CreateIfNotExistsAsync();

        var uniqueFileName =
            $"{Guid.NewGuid()}-{fileName}";

        var blobClient =
            blobContainerClient.GetBlobClient(uniqueFileName);

        await blobClient.UploadAsync(
            stream,
            overwrite: true
        );

        return blobClient.Uri.ToString();
    }
}
