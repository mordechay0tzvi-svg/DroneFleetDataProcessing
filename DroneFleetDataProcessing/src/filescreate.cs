using System;
using System.IO;
namespace drones
{
    class CreateFiles
    {
        public List<string> Create()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentFolder = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));
            string targetFolder = Path.Combine(parentFolder, "output");
            string filePath1 = Path.Combine(targetFolder, "report_analysis.txt");
            string filePath2 = Path.Combine(targetFolder, "clean_drones.json");
            File.WriteAllText(filePath1, "DRONE FLEET ANALYSIS REPORT");
            File.WriteAllText(filePath2, "");
            return new List<string> { filePath1, filePath2 };
        }
    }
}