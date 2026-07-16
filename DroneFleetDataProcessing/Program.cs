using System.Diagnostics;
using drones; 

namespace drones
{
    class Program
    {

        static void Main()
        {
            CreateFiles s = new CreateFiles();
            List<string> pathsFiles = s.Create();
            string path = pathsFiles[1];
            Process f = new Process();
            
          List<Drone>? d  = f.InitialProcess("drones_all_invalid.json");
            f.FilterDrones(d);
        }
    }
}
