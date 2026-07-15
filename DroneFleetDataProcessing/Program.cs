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
            
            f.InitialProcess("drones_null.json");
        }
    }
}
