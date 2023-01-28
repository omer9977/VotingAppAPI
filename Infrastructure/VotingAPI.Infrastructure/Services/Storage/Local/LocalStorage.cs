using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Abstractions.Storage.Local;

namespace VotingAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IHostingEnvironment _webHostEnvironment;
        public LocalStorage(IHostingEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log
                throw ex;
            }
        }

        public async Task DeleteFileAsync(string path, string fileName)
        => File.Delete($"{path}\\{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directoryInfo = new(path);
            return directoryInfo.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            //List<bool> results = new();
            foreach (IFormFile file in files)
            {
                //string fullPath = $"{uploadPath}\\{file.FileName}";
                await CopyFileAsync($"{uploadPath}\\{file.FileName}{Path.GetExtension(file.FileName)}", file);
                datas.Add((file.FileName, $"{path}\\{file.FileName}"));
                //results.Add(result);
            }

            //if (results.TrueForAll(x => x.Equals(true)))
            //    return datas;
            return datas;
        }
    }
}
