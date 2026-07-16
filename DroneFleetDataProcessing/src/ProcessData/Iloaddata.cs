using drones;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneFleetDataProcessing.src.ProcessData
{
    interface Iloaddata
    {
        public List<Drone>? InitialProcess(string data);
        
    }
}
