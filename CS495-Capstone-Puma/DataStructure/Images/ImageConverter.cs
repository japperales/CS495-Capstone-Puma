using System.IO;
using System.Drawing;

namespace CS495_Capstone_Puma.DataStructure.Images
{
    public static class ImageConverter
    {
        public static int[] GetDimensionsOfMemoryStream(MemoryStream memorySteam)
        {
            int[] dimensions = new int[2];
            var image = Image.FromStream(memorySteam);
            
            var height = image.Height;
            var width = image.Width;
            
            dimensions[0] = height;
            dimensions[1] = width;
            
            return dimensions;
        }
            
    }
}