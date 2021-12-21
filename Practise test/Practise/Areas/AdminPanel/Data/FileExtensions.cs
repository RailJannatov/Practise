using Microsoft.AspNetCore.Http;

namespace Practise.Areas.AdminPanel.Data
{
    public static class FileExtensions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsSizeAllowed(this IFormFile file, int mb)
        {
            return file.Length < mb * 1000 * 1024;
        }
    }
}
