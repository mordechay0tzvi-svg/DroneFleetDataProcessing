using System;
using System.IO;
namespace drones
{
    class CreateFiles
    {
        static List<string> Create()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentFolder = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));
            string targetFolder = Path.Combine(parentFolder, "output");
            string filePath1 = Path.Combine(targetFolder, "report_analysis.txt");
            string filePath2 = Path.Combine(targetFolder, "clean_drones.json");
            File.Create(filePath1).Dispose();
            File.Create(filePath2).Dispose();
            return new List<string> { filePath1, filePath2 };
        }
    }
}