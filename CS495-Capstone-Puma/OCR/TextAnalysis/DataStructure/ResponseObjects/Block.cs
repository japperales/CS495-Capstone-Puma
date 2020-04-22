﻿using System.Collections.Generic;
 using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects
{
    public class Block
    {
        [JsonProperty("Geometry")]
        public Geometry Geometry { get; set; }
        
        [JsonProperty("Text")]
        public string Text { get; set; }
        
        [JsonProperty("Relationships")]
        public List<Relationship> Relationships { get; set; }
        
        [JsonProperty("Confidence")]
        public double Confidence { get; set; }
        
        [JsonProperty("RowSpan")]
        public int RowSpan { get; set; }

        [JsonProperty("RowIndex")]
        public int RowIndex { get; set; }

        [JsonProperty("ColumnSpan")]
        public int ColumnSpan { get; set; }

        [JsonProperty("ColumnIndex")]
        public int ColumnIndex { get; set; }

        [JsonProperty("BlockType")]
        public string BlockType { get; set; }
        
        [JsonProperty("Id")]
        public string Id { get; set; }
        
        [JsonProperty("Page")]
        public int Page { get; set; }


        public Block()
        {
            Geometry = new Geometry();
            Text = "";
            Relationships = new List<Relationship>();
            Confidence = 0;
            RowSpan = 0;
            RowIndex = 0;
            ColumnSpan = 0;
            ColumnIndex = 0;
            BlockType = "";
            Id = "";
            Page = 0;
        }
        
        //No Relationship
        public Block(Geometry geometry, string text, double confidence, int rowSpan, int rowIndex, int columnSpan, int columnIndex, string blockType, string id, int page)
        {
            Geometry = geometry;
            Text = text;
            Relationships = new List<Relationship>();
            Confidence = confidence;
            RowSpan = rowSpan;
            RowIndex = rowIndex;
            ColumnSpan = columnSpan;
            ColumnIndex = columnIndex;
            BlockType = blockType;
            Id = id;
            Page = page;
        }
        
        //No Text
        public Block(Geometry geometry, List<Relationship> relationships, double confidence, int rowSpan, int rowIndex, int columnSpan, int columnIndex, string blockType, string id, int page)
        {
            Geometry = geometry;
            Text = "";
            Relationships = relationships;
            Confidence = confidence;
            RowSpan = rowSpan;
            RowIndex = rowIndex;
            ColumnSpan = columnSpan;
            ColumnIndex = columnIndex;
            BlockType = blockType;
            Id = id;
            Page = page;
        }
        
        //No Relationship or Text
        public Block(Geometry geometry, double confidence, int rowSpan, int rowIndex, int columnSpan, int columnIndex, string blockType, string id, int page)
        {
            Geometry = geometry;
            Text = "";
            Relationships = new List<Relationship>();
            Confidence = confidence;
            RowSpan = rowSpan;
            RowIndex = rowIndex;
            ColumnSpan = columnSpan;
            ColumnIndex = columnIndex;
            BlockType = blockType;
            Id = id;
            Page = page;
        }
        
        [JsonConstructor]
        public Block(Geometry geometry, string text, List<Relationship> relationships, double confidence, int rowSpan, int rowIndex, int columnSpan, int columnIndex, string blockType, string id, int page)
        {
            Geometry = geometry;
            Text = text;
            Relationships = relationships;
            Confidence = confidence;
            RowSpan = rowSpan;
            RowIndex = rowIndex;
            ColumnSpan = columnSpan;
            ColumnIndex = columnIndex;
            BlockType = blockType;
            Id = id;
            Page = page;
        }
        
    }
}