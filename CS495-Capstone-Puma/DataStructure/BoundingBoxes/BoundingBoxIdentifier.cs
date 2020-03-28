using System.Dynamic;

namespace CS495_Capstone_Puma.DataStructure.BoundingBoxes
{
    public class BoundingBoxIdentifier
    {
        public int[] Coord = new int[4];

        public string Label { get; set; }


        public BoundingBoxIdentifier(int x, int y, int width, int height, string label)
        {
            Coord[0] = x;
            Coord[1] = y;
            Coord[2] = width;
            Coord[3] = height;

            Label = label;
        }
    }
}