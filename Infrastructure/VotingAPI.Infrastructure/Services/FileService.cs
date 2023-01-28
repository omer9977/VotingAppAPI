using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;

namespace VotingAPI.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _webHostEnvironment;
        public FileService(IHostingEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


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
    }
}