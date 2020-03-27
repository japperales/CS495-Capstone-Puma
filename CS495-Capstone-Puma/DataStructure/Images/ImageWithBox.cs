using CS495_Capstone_Puma.DataStructure.BoundingBoxes;

namespace CS495_Capstone_Puma.DataStructure.Images
{
    public class ImageWithBox
    {
        public string image { get; set; }
        
        public BoundingBox box { get; set; }


        public ImageWithBox(BoundingBox box, string image)
        {
            this.image = image;
            this.box = box;
        }
        
    }
}