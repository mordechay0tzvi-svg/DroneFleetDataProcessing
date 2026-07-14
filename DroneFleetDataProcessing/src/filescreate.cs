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
            string jsonPath = Path.Combine(outputDir, "json.clean_drones");
            string reportPath = Path.Combine(outputDir, "txt.report_analysis");
            File.WriteAllText(jsonPath, "{}");
            File.WriteAllText(reportPath, "\n");
            
        }
    }
}