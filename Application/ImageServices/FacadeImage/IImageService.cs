
using Application.ImageServices.ImageComposer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ImageServices.FacadeImage
{
    public interface IImageService
    {
        IImageUploadService ImageUploader { get; }

        IImageComposerService ImageComposer { get; }
    }

    public class ImageService : IImageService
    {
        private IImageUploadService imageUploader;
        public IImageUploadService ImageUploader =>
            imageUploader ?? new ImageUploadService();


        private IImageComposerService imageComposer;
        public IImageComposerService ImageComposer =>
            imageComposer ?? new ImageComposerService();
    }
}
