using System.Dynamic;

namespace CS495_Capstone_Puma.DataStructure.BoundingBoxes
{
    public class BoundingBox
    {
        public int[] coord = new int[4];

        public string label { get; set; }


        public BoundingBox(int x, int y, int width, int height, string label)
        {
            coord[0] = x;
            coord[1] = y;
            coord[2] = width;
            coord[3] = height;

            this.label = label;
        }
        
        
    }
}