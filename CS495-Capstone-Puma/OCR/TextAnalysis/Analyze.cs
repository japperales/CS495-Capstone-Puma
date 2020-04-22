using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CS495_Capstone_Puma.OCR.DataStructure;
using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects;
using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.OCR.TextAnalysis
{
    public static class Analyze
    {
        public static async Task<TextractResponse> AnalyzeFile(string fileName)
        {
            Dictionary<string, string> file = new Dictionary<string, string> {{"fileName", fileName}};
            string ServerAddress = "https://localhost:5003";
            

            TextractResponse getResp = await (ServerAddress.AppendPathSegment(fileName))
                .GetJsonAsync<TextractResponse>();

            return getResp;
        }
        
        public static List<Block> GetChildrenRecursive(Dictionary<string, Block> blockDictionary, Block block,
            List<Block> targetList)
        {
            //for each child, add that block to the list
            if (!(block.Relationships is null))
            {
                foreach (Relationship relationship in block.Relationships)
                {
                    if (relationship.Type.Equals("CHILD"))
                    {
                        foreach (var id in relationship.Ids)
                        {
                            if (!targetList.Contains(blockDictionary[id]))
                            {
                                targetList.Add(blockDictionary[id]);
                            }
                            
                            targetList = GetChildrenRecursive(blockDictionary, blockDictionary[id], targetList);
                        }
                    }
                }
            }
            return targetList;
        }
    }
}
