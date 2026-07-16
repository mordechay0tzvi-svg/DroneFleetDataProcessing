using DroneFleetDataProcessing.src.ProcessData;
using drones;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.Json;
using System.Xml;


namespace drones
{
    class ProcessJsonFile : IloadData<string>
    {
         public List<Drone>? InitialProcess(string filename)
        {
            try
            {             
                
                string folderPath = Path.Combine("input", "raw", filename);
                string loadJson = File.ReadAllText(folderPath);
                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                
                if (loadJson.Length == 0) 
                {
                    throw new EmptyJsonFile("Error: EmptyJsonFile - the file is empty ");
                }    
                
                List<Drone>? drones = JsonSerializer.Deserialize<List<Drone>>(loadJson, options);
                if (drones == null) throw new NullReferenceException("The JSON content was successfully read but resolved to null.");
                return drones;
            }
            
            catch (EmptyJsonFile ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
          
            
            catch (FileNotFoundException) 
            {
                Console.WriteLine("Erorr: FileNotFoundException - file not found ");
                return null;
       
            }
            catch (UnauthorizedAccessException  )
            {

                Console.WriteLine("Error: UnauthorizedAccessException - dont have access to the file");

                return null;
            }
            
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error: NullReferenceException - {ex.Message}");
                return null;
            }

            catch (JsonException ex)
            {    
            Console.WriteLine($"Error: MalformedError {ex.Message}");
                return null;
            }

            
           

        }

        public List<Drone> FilterDrones(List<Drone> drones)
        {
            DroneValidator valdator = new DroneValidator();
            List<Drone> validDrones = new List<Drone>();
            List<int> ides = new List<int>();
            List<string> serials = new();

            foreach (Drone drone in drones)
            {
                bool isValidReport = valdator.Validate(drone);
                if (isValidReport && !(ides.Contains(drone.id)) && !(serials.Contains(drone.serialNumber))) { validDrones.Add(drone); ides.Add(drone.id); serials.Add(drone.serialNumber); }
            }
        
                
            return validDrones;
        }

        public bool isAllDronesInvalid (List<Drone> validDrones)
        {
            try
            {
                if (validDrones.Count == 0) throw new DronsInvalidException("Error: DronsInvalidException - all drones are invalid");
                return true;
            }
            catch (DronsInvalidException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
