
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ImageServices
{
    public interface IImageUploadService
    {
        Task<List<string>> Execute(List<IFormFile> files);
    }

    public class ImageUploadService : IImageUploadService
    {
        public async Task<List<string>> Execute(List<IFormFile> files)
        {
            var client = new RestClient("http://staticfiles.thirtythreee.ir/api/image");
            var request = new RestRequest();
            request.Method = Method.Post;

            foreach (var file in files)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    bytes = ms.ToArray();
                }

                request.AddFile(file.FileName, bytes, file.FileName, file.ContentType);
            }

            var response = client.ExecutePostAsync(request).Result;

            var upload = JsonConvert.DeserializeObject<UploadDto>(response.Content);

            return upload.AddressOfImages;
        }
    }

    public class UploadDto
    {
        public List<string>? AddressOfImages { get; set; }
    }

}
