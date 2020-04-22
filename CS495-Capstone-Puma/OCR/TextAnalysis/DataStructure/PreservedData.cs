using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure.Asset.AssetCategory;
using CS495_Capstone_Puma.DataStructure.BoundingBoxes;
using CS495_Capstone_Puma.Model;
using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects;
using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects;
using CS495_Capstone_Puma.OCR.TextAnalysis;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.OCR.DataStructure
{
    public class PreservedData
    {
        [JsonProperty("Blocks")] public List<Block> Blocks { get; set; }

        [JsonProperty("BoundingBoxIdentifiers")]
        public List<BoundingBoxIdentifier> BoundingBoxIdentifiers { get; set; }

        public PreservedData()
        {
            Blocks = new List<Block>();
            BoundingBoxIdentifiers = new List<BoundingBoxIdentifier>();
        }

        [JsonConstructor]
        public PreservedData(List<Block> blocks, List<BoundingBoxIdentifier> boundingBoxIdentifiers)
        {
            Blocks = blocks;
            BoundingBoxIdentifiers = boundingBoxIdentifiers;
        }

        public List<Block> FilterToChildren(string blockId)
        {
            Dictionary<string, Block> allBlocks = new Dictionary<string, Block>();
            foreach (var block in Blocks)
            {
                allBlocks.Add(block.Id, block);
                
            }
            List<Block> children = new List<Block>();
            return Analyze.GetChildrenRecursive(allBlocks, allBlocks[blockId], children);
        }

        public Block[,] ConstructTable(string tableId)
        {
            int column = 0;
            int row = 0;
            Dictionary<string, Block> allBlocks = new Dictionary<string, Block>();
            foreach (var block in Blocks)
            {
                allBlocks.Add(block.Id, block);
            }

            foreach (var relationship in allBlocks[tableId].Relationships)
            {
                if (relationship.Type.Equals("CHILD"))
                {
                    foreach (var id in relationship.Ids)
                    {
                        Block block = allBlocks[id];
                        column = Math.Max(column, block.ColumnIndex);
                        row = Math.Max(row, block.RowIndex);
                    }
                }
            }

            Block[,] table = new Block[column, row];
            foreach (var relationship in allBlocks[tableId].Relationships)
            {
                if (relationship.Type.Equals("CHILD"))
                {
                    foreach (var id in relationship.Ids)
                    {
                        Block block = allBlocks[id];
                        //Adjust so Column 1 maps to index 0
                        if (block.BlockType.Equals("CELL"))
                        {
                            table[block.ColumnIndex - 1, block.RowIndex - 1] = block;
                        }
                    }
                }
            }
            
            return table;
        }

        public int[] FindIndex(Block[,] table, List<Block> fullList, List<string> searchParams)
        {
            Dictionary<string, Block> allBlocks = new Dictionary<string, Block>();
            foreach (var block in fullList)
            {
                allBlocks.Add(block.Id, block);
            }

            for (int y = 0; y < table.GetLength(1); y++)
            {
                for (int x = 0; x < table.GetLength(0); x++)
                {
                    //get a CELL in ROW 1
                    Block cell = table[x, y];
                    if (!(cell.Relationships is null))
                    {
                        //check all of its children for the words Holdings or Assets
                        foreach (var relationship in cell.Relationships)
                        {
                            if (relationship.Type.Equals("CHILD"))
                            {
                                foreach (var id in relationship.Ids)
                                {
                                    if (searchParams.Contains(allBlocks[id].Text.ToLower()))
                                    {
                                        //return the column index
                                        return new[] {x, y};
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // add other search cases
        
        
            // if nothing found, return -1
            return new[]{ -1, -1 };
        }


        public string GetAllTextFromCell(Block cell, List<Block> fullList)
        {
            Dictionary<string, Block> allBlocks = new Dictionary<string, Block>();
            foreach (var block in fullList)
            {
                allBlocks.Add(block.Id, block);
            }

            string result = "";
            if (!(cell.Relationships is null))
            {
                foreach (Relationship relationship in cell.Relationships)
                {
                    if (relationship.Type.Equals("CHILD"))
                    {
                        foreach (var id in relationship.Ids)
                        {
                            if (allBlocks[id].BlockType.Equals("WORD"))
                            {
                                result = result + " " + allBlocks[id].Text;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}