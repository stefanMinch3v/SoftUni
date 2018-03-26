namespace LearningSystem.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Threading.Tasks;

    public static class FormFileExtensions
    {
        public static async Task<byte[]> ToByteArrayAsync(this IFormFile formFile)
        {
            // memory stream reads/writes in the ram memory
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
