using drones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace drones
{
    class Process
    {
         public List<Drone>? InitialProcess()
        {
            try
            {
                //string folderPath = Path.Combine("input", "raw", "drones_raw.json");

                //string loadJson = File.ReadAllText(folderPath);

                //var options = new JsonSerializerOptions();

                //List<Drone>? drones = JsonSerializer.Deserialize<List<Drone>>(loadJson);
                //if (drones == null) throw new NullReferenceException("The JSON content was successfully read but resolved to null.");
                //return drones;
                string folderPath = Path.Combine("input", "test_scenarios", "drones_empty.json");
                string loadJson = File.ReadAllText(folderPath);
                var options = new JsonSerializerOptions();

                List<Drone>? drones = JsonSerializer.Deserialize<List<Drone>>(loadJson);
                if (drones == null) throw new NullReferenceException("The JSON content was successfully read but resolved to null.");
                return drones;
            }
            catch (FileNotFoundException) 
            {
                Console.WriteLine("Erorr: FileNotFoundException - file not found ");
                return null;
       
            }
            catch (UnauthorizedAccessException  )
            {
                File.AppendAllText("report_analysis.txt","Error: UnauthorizedAccessException - dont have access to the file");

                return null;
            }
            catch (JsonException)
            {
                File.AppendAllText("report_analysis.txt", "Erorr: JsonException - the json file corapted");
                return null;
               
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error: NullReferenceException - {ex.Message}");
                File.AppendAllText("report_analysis.txt", $"Error: NullReferenceException - {ex.Message}");
                return null;
            }


        }
    }
}
