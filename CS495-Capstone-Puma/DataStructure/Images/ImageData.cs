using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CS495_Capstone_Puma.DataStructure.Images
{
    public class ImageData
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }
        
        [JsonProperty("image")]
        public IFormFile Image { get; set; }

        public ImageData()
        {
            FileName = "";
            Image = new FormFile(Stream.Null, 0,0,"", FileName);
        }

        [JsonConstructor]
        public ImageData(string fileName, IFormFile image)
        {
            FileName = fileName;
            Image = image;
        }
    }
}