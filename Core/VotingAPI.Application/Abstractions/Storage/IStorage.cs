using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);
        List<string> GetFiles(string path);
        Task DeleteFileAsync(string path, string fileName);
        bool HasFile(string path, string fileName);
    }
}
