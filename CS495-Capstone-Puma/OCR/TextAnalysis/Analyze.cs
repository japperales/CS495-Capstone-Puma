using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CS495_Capstone_Puma.OCR.DataStructure;
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
    }
}
