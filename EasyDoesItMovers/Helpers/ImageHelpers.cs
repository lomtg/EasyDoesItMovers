using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Helpers
{
    public static class ImageHelpers
    {
        public static Byte[] TurnImageIntoBytes(IFormFile imageData)
        {
            Byte[] imageDataInBytes;
            MemoryStream ms = new MemoryStream();
            imageData.CopyTo(ms);

            imageDataInBytes = ms.ToArray();

            ms.Close();
            ms.Dispose();

            return imageDataInBytes;
        }
    }
}
