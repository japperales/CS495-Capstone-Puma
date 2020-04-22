using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure.Asset.AssetCategory;
using CS495_Capstone_Puma.DataStructure.BoundingBoxes;
using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects;
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
                        table[block.ColumnIndex - 1, block.RowIndex - 1] = block;
                    }
                }
            }
            
            return table;
        }

        public int findAssetIndex(Block[,] table, List<Block> fullList)
        {
            Dictionary<string, Block> allBlocks = new Dictionary<string, Block>();
            foreach (var block in fullList)
            {
                allBlocks.Add(block.Id, block);
            }
            
            //Check headers
            for (int i = 0; i < table.GetLength(0); i++)
            {
                //get a CELL in ROW 1
                Block cell = table[i, 0];

                //check all of its children for the words Holdings or Assets
                foreach (var relationship in cell.Relationships)
                {
                    if (relationship.Type.Equals("CHILD"))
                    {
                        foreach (var id in relationship.Ids)
                        {
                            if ( allBlocks[id].Text.ToLower().Contains("asset") || allBlocks[id].Text.ToLower().Contains("holding"))
                            {
                                //return the column index
                                return i;
                            }
                        }
                    }
                }
            }
// add other search cases
// if nothing found, return 0
            return -1;
        }
    }
}