using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EventEase.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _client;

        public BlobService(string connectionString)
        {
            _client = new BlobServiceClient(connectionString);
        }

        
    }
}
