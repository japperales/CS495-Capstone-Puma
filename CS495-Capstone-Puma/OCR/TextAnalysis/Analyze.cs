using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
 using CS495_Capstone_Puma.OCR.DataStructure;
 using Newtonsoft.Json;

namespace CS495_Capstone_Puma.OCR.TextAnalysis
{
    public static class Analyze
    {
        public static TextractResponse AnalyzeFile(string fileName)
        {

            Console.Out.WriteLine("Executing Python...");
            // 1) Create Process Info
            var psi = new ProcessStartInfo {FileName = @"C:\Python27\python.exe"};
            var script = @"..\..\CS495-Capstone-Puma\OCR\TextAnalysis\awsScript.py";
            
            psi.Arguments = $"\"{script}\" \"{fileName}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            
            TextractResponse textractResponse = new TextractResponse();
            using(var process = Process.Start(psi))
            {
                if (process != null)
                {
                    StreamReader reader = process.StandardOutput;
                    string pythonOutput = reader.ReadToEnd();
                    Console.Out.WriteLine("read Output");
                    Console.Out.WriteLine(pythonOutput.Length);

                    textractResponse = JsonConvert.DeserializeObject<List<TextractResponse>>(pythonOutput)[0];
                    process.WaitForExit();
                }
            }
            return textractResponse;
        }
    }
}
