using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Practise.Areas.AdminPanel.Data
{
    public static class FileUtil
    {
        public static async Task<string> GenerateFile(string folderName, IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
            var path = Path.Combine(folderName, fileName);

            var fileStream = new FileStream(path, FileMode.CreateNew);
            await file.CopyToAsync(fileStream);

            return fileName;
        }
    }
}
