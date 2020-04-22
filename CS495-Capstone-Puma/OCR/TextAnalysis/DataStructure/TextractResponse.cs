﻿using System.Collections.Generic;
 using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.OCR.DataStructure
{
    public class TextractResponse
    {
        [JsonProperty("AnalyzeDocumentTextModelVersion")]
        public string AnalyzeDocumentTextModelVersion { get; set; }
        
        [JsonProperty("Blocks")]
        public List<Block> Blocks { get; set; }
        
        [JsonProperty("DocumentMetadata")]
        public DocumentMetadataObject DocumentMetadata { get; set; }

        [JsonProperty("JobStatus")]
        public string JobStatus { get; set; }

        public TextractResponse()
        {
            AnalyzeDocumentTextModelVersion = "";
            Blocks = new List<Block>();
            DocumentMetadata = new DocumentMetadataObject();
            JobStatus = "";
        }

        [JsonConstructor]
        public TextractResponse(string analyzeDocumentTextModelVersion, List<Block> blocks, DocumentMetadataObject documentMetadata, string jobStatus)
        {
            AnalyzeDocumentTextModelVersion = analyzeDocumentTextModelVersion;
            Blocks = blocks;
            DocumentMetadata = documentMetadata;
            JobStatus = jobStatus;
        }
        
        //Filter rawBlocks by confidence
        //Threshold is a double between 0 and 100
        public List<Block> FilterConfidence(double threshold)
        {
            List<Block> matchingBlocks = new List<Block>();
            foreach (Block block in Blocks)
            {
                if (block.Confidence >= threshold)
                {
                    matchingBlocks.Add(block);
                }
            }

            return matchingBlocks;
        }
        
        //Filter rawBlocks by type
        //blockType is a string: PAGE, LINE, WORD, TABLE, CELL, or FIELD
        public List<Block> FilterType(string blockType)
        {
            blockType = blockType.ToUpper();
            
            List<Block> matchingBlocks = new List<Block>();
            foreach (Block block in Blocks)
            {
                if (block.BlockType == blockType)
                {
                    matchingBlocks.Add(block);
                }
            }

            return matchingBlocks;
        }
        
        //Filter rawBlocks by page
        //Page is an int of the page number
        public List<Block> FilterPage(int page)
        {
            List<Block> matchingBlocks = new List<Block>();
            foreach (Block block in Blocks)
            {
                if (block.Page == page)
                {
                    matchingBlocks.Add(block);
                }
            }

            return matchingBlocks;
        }
        
        //Filter rawBlocks by text contents
        //Page is a string to match Text
        public List<Block> FilterTextExact(string text)
        {
            List<Block> matchingBlocks = new List<Block>();
            foreach (Block block in Blocks)
            {
                if (block.Text.Equals(text))
                {
                    matchingBlocks.Add(block);
                }
            }

            return matchingBlocks;
        }
        
        //Filter rawBlocks by text contents
        //Page is a string to match Text
        public List<Block> FilterTextContains(string text)
        {
            List<Block> matchingBlocks = new List<Block>();
            foreach (Block block in Blocks)
            {
                if (block.Text.Contains(text))
                {
                    matchingBlocks.Add(block);
                }
            }
            return matchingBlocks;
        }
    }
}