using System.IO;
namespace drones
{
    class CreateFiles
    {
        static void Create()
        {
            
            string projectDir = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            string outputDir = Path.Combine(projectDir, "output");
            Directory.CreateDirectory(outputDir);
            string jsonPath = Path.Combine(outputDir, "clean_drones.json");
            string reportPath = Path.Combine(outputDir, "report_analysis.txt");
            File.WriteAllText(jsonPath, "{}");
            File.WriteAllText(reportPath, "\n");
            
        }
    }
}