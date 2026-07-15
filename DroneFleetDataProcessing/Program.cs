using System.Diagnostics;
using drones; 

namespace drones
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Drone Fleet Data Processing System ===");
            Console.WriteLine("Step 1: Reading raw data...");
            Console.WriteLine("Reading records from raw file");
            Process f = new Process();
            List<Drone>? allDrones = f.InitialProcess("drones_raw.json");
            if (allDrones == null)
            {
                Console.WriteLine("Failed to read file.");
                return;
            }
            Console.WriteLine("Step 2: Validating data and creating clean dataset...");
            List<Drone>? validDrone = f.FilterDrones(allDrones);
            if (validDrone == null)
            {
                Console.WriteLine("No valid drones in file.");
                return;
            }
            Console.WriteLine($"Valid records: {validDrone.Count}");
            Console.WriteLine($"Rejected records: {allDrones.Count - validDrone.Count}");
            Console.WriteLine("Step 3: Saving clean data...");
            CreateFiles cr = new();
            List<string> paths = cr.Create();
            Console.WriteLine($"Clean data saved to: {paths[0]}");
            Console.WriteLine("Step 4: Reloading clean data...");
            Console.WriteLine("Loaded records from clean dataset");
            Console.WriteLine("Step 5: Performing analysis...");
            AllData reporter = new(paths[1], paths[0], allDrones, validDrone);
            Console.WriteLine("Analysis completed successfully");
            Console.WriteLine("Step 6: Generating report...");
            reporter.GetReport();
            Console.WriteLine($"Report generated successfully: {paths[1]}");
            Console.WriteLine("=== Process completed successfully! ===");
            Console.ReadKey();
        }
    }
}
