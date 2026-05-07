using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace EventEase.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _client;
        public BlobService(string connectionString)
        {
            _client = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var container = _client.GetBlobContainerClient("venue-images");

            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlobClient(file.FileName);

            using var stream = file.OpenReadStream();

            await blob.UploadAsync(stream);

            return blob.Uri.ToString();


        }
    }
}
