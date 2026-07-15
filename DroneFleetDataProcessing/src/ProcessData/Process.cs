using drones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DroneFleetDataProcessing.src.Process
{
    class Process
    {
        public static CreateFiles cr = new CreateFiles();
        public static string reportAnalysisFilePath = cr.Create()[0];
        public static string cleanDronesFilePath = cr.Create()[1];
        public static List<Drone> InitialProcess()
        {
            string folderPath = Path.Combine("input", "raw", "drones_raw.json");
            string loadJson = File.ReadAllText(folderPath);
            //Console.WriteLine(string.Join(", ",loadJson));
            var options = new JsonSerializerOptions();
            List<Drone> drones = JsonSerializer.Deserialize<List<Drone>>(loadJson) ?? new();
            return drones;
        }




        public static List<Drone> FilterDrones()
        {
            List<Drone> goodDrones = new();
            DroneValidator droneValidator = new DroneValidator();
            foreach (Drone drone in InitialProcess())
            {
                if (droneValidator.Validate(drone))
                {
                    goodDrones.Add(drone);
                }
            }
            return goodDrones;
        }    
 }
