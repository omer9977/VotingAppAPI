using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions.Storage.Azure;

namespace VotingAPI.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient _blobContainerClient;
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }

        public async Task DeleteFileAsync(string path, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string path)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }
        //public string GetFile(string path)
        //{
        //    _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
        //    return _blobContainerClient.GetBlobs().Select(b => b.Name);
        //}

        public bool HasFile(string path, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string path)> datas = new();
            foreach (var file in files) 
            {
                BlobClient blobClient = _blobContainerClient.GetBlobClient(file.FileName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((file.FileName, $"{path}/{file.FileName}"));
            }
            return datas;
        }
    }
}
