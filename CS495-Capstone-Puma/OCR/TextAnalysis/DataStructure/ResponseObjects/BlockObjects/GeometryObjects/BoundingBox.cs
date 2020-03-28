﻿using Newtonsoft.Json;

namespace CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects.GeometryObjects
{
    public class BoundingBox
    {
        [JsonProperty("Top")]
        public double Top { get; set; }
        
        [JsonProperty("Left")]
        public double Left { get; set; }
        
        [JsonProperty("Height")]
        public double Height { get; set; }
        
        [JsonProperty("Width")] 
        public double Width { get; set; }

        public BoundingBox()
        {
            Top = 0;
            Left = 0;
            Height = 0;
            Width = 0;
        }
        
        [JsonConstructor]
        public BoundingBox(double top, double left, double height, double width)
        {
            Top = top;
            Left = left;
            Height = height;
            Width = width;
        }
    }
}