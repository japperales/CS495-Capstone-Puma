﻿using System.Collections.Generic;
 using Newtonsoft.Json;

namespace CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects
{
    public class Relationship
    {
        [JsonProperty("Type")]
        public string Type { get; set; }
        
        [JsonProperty("Ids")]
        public List<string> Ids { get; set; }
        
        public Relationship()
        {
            Type = "";
            Ids = new List<string>();
        }
        
        [JsonConstructor]
        public Relationship(string type, List<string> ids)
        {
            Type = type;
            Ids = ids;
        }
        
    }
}