﻿using System.Collections.Generic;
 using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects.GeometryObjects;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects
{
    public class Geometry
    {
        [JsonProperty("BoundingBox")]
        public BoundingBox BoundingBox { get; set; }
        
        [JsonProperty("Polygon")]
        public List<Coordinate> Polygon { get; set; }
    }
}