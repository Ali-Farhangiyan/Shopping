using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace StaticFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IHostingEnvironment env;

        public ImageController(IHostingEnvironment env)
        {
            this.env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                return Ok(await Uplaod(files));
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UploadDto> Uplaod(IFormFileCollection files)
        {
            var date = DateTime.Now;
            
            var folder = $@"Resources\images\{date.Year}\{date.Year}-{date.Month}\";
            var uploadFolder = Path.Combine(env.WebRootPath, folder);
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            var listAdd = new List<string>();
            foreach (var file in files)
            {
                var guidName = Guid.NewGuid().ToString();
                var newFileName = guidName + file.FileName;
                var pathImage = Path.Combine(uploadFolder, newFileName);

                using(var fs = new FileStream(pathImage, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                listAdd.Add(folder + newFileName);

            }

            return new UploadDto
            {
                AddressOfImages = listAdd
            };
        }
    }

    public class UploadDto
    {
        public List<string>? AddressOfImages { get; set; }
    }
}
