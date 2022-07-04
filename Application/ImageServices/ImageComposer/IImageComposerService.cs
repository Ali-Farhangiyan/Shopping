using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ImageServices.ImageComposer
{
    public interface IImageComposerService
    {
        string Execute(string src);
    }

    public class ImageComposerService : IImageComposerService
    {
        public string Execute(string src)
        {
            var uri = "http://staticfiles.thirtythreee.ir/";
            return uri + src;
        }
    }
}
