using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects.GeometryObjects;

namespace CS495_Capstone_Puma.DataStructure.Images
{
    public class ImageWithBox
    {
        public string Image { get; set; }
        
        public BoundingBox Box { get; set; }


        public ImageWithBox(BoundingBox box, string image)
        {
            Image = image;
            Box = box;
        }
        
    }
}