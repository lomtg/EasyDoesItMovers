using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Helpers
{
    public static class RetrieveImage
    {
        public static string GetImageURL(this Byte[] imageData)
        {
                string imageBase64Data = Convert.ToBase64String(imageData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                return imageDataURL;      
        }
    }
}
