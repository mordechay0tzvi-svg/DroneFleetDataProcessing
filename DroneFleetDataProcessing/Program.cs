using System.Diagnostics;
using drones; 

namespace drones
{
    class Program
    {

        static void Main()
        {
            Process f = new Process();
            List<Drone>? allDrones = f.InitialProcess("drones_raw.json");
            List<Drone>? validDrone = f.FilterDrones(allDrones);
            CreateFiles cr = new();
            List <string> paths = cr.Create();
            AllData reporter = new(paths[1], paths[0], allDrones, validDrone);
            reporter.GetReport();
        }
    }
}
