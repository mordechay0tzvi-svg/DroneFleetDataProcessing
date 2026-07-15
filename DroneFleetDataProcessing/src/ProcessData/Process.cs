using drones;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.Json;
using System.Xml;


namespace drones
{
    class Process
    {
         public List<Drone>? InitialProcess(string fileName)
        {
            try
            {             
                //List<Drone>? drones = new List<Drone>();
                string folderPath = Path.Combine("input", "test_scenarios", fileName);
                string loadJson = File.ReadAllText(folderPath);
                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                
                if (string.IsNullOrWhiteSpace(loadJson)) throw new NullReferenceException("The JSON content was successfully read but resolved to null.");
                

                if (loadJson.Length == 0) 
                {
                    throw new EmptyJsonFile("Error: EmptyJsonFile - the file is empty ");
                }
                
                //foreach (string dronej in loadJson)
                //{
                //    try
                //    {
                       
                //        drones.Add(drone);

                //    }
                //    catch (JsonException )
                //    { continue; }
                    
                //}

                List<Drone>? drones = JsonSerializer.Deserialize<List<Drone>>(loadJson, options);
                //if (drones.Count == 0) throw new DronsInvalidException("The JSON content was successfully read but all drons are invalid.");
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
                string errorMsg;

                // אם הבעיה היא בטיפוס הנתונים (יש נתיב ספציפי לשדה הבעייתי)
                if (!string.IsNullOrEmpty(ex.Path))
                {
                    errorMsg = $"JSON data type mismatch at property '{ex.Path}.";
                }
                // אם הבעיה היא בעיית תחביר (פסיק חסר, סוגרייוכו זקוק לשינוי לגבי שגיאה אם כול האובייקטים שגואיים ולא רק אחד ')
                else
                {
                    errorMsg = $"JSON syntax - error (malformed) at line {ex.LineNumber}, position {ex.BytePositionInLine}.";
                }

                Console.WriteLine($"Error: {errorMsg}");
                return null;
            }

            catch (DronsInvalidException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public List<Drone>? FilterDrones(List<Drone> drones)
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
            Console.WriteLine(validDrones.Count);
            return validDrones;
        }
    }
}
