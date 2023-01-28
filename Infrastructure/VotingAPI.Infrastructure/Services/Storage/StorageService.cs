using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions.Storage;

namespace VotingAPI.Infrastructure.Services.Storage
{
    internal class StorageService : IStorageService
    {
        private readonly IStorage _storage;
        private readonly IConfiguration _configuration;
        public StorageService(IStorage storage, IConfiguration configuration)
        {
            _storage = storage;
            _configuration = configuration;
        }

        public string StorageName { get => _storage.GetType().Name; }

        //public Task<bool> CopyFileAsync(string path, IFormFile file)
        //=> _storage.CopyFileAsync(path, file);

        public Task DeleteFileAsync(string path, string fileName)
        => _storage.DeleteFileAsync(path, fileName);

        public List<string> GetFiles(string path)
        => _storage.GetFiles(path);

        public bool HasFile(string path, string fileName)
        => _storage.HasFile(path, fileName);

        public Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        => _storage.UploadAsync(path, files);
    }
}
