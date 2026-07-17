using drones;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneFleetDataProcessing.src.ProcessData
{
    interface IloadData<T>
    {
        public List<Drone>? InitialProcess(T data);
        
    }
}
