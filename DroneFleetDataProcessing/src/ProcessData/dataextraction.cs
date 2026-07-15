using drones;

namespace DroneFleetDataProcessing.src.ProcessData
{
    class AllData
    {
        Process prc = new Process();
        List<Drone> all = prc.InitialProcess();
        List<Drone> good = prc.FilterDrones();
        public static void ShowDroneFile()
        {
            File.WriteAllLines(prc.cleanDronesFilePath, JsonSerializer.Serialize<List<Drone>>(prc.FilterDrones()));
        }
        public void ProcessingSummary()
        {
            File.AppendText(prc.reportAnalysisFilePath, $"Total raw records: {all.Count}");
            File.AppendText(prc.reportAnalysisFilePath, $"Valid records: {good.Count}");
            File.AppendText(prc.reportAnalysisFilePath, $"Rejected records: {all.Count - good.Count}");
        }
        public void NoneOperationalDrones()
        {
            File.AppendText(prc.reportAnalysisFilePath, "NON - OPERATIONAL DRONES");
            var nonOpDrone = good.Where(d => d.status != "Operational").Select(d => new { serialNumber = d.serialNumber, model = d.model, lbase = d.base_location, status = d.status });
            if (nonOpDrone == null) { File.AppendText(prc.reportAnalysisFilePath,"Non operational drone not found."); return; }
            foreach (var drone in nonOpDrone) 
            {
                File.AppendText(prc.reportAnalysisFilePath, $"{drone.serialNumber} | {drone.model} | {drone.lbase} | {drone.status}");
            }
        }
        public void Top5Hours() 
        {
            File.AppendText(prc.reportAnalysisFilePath, "TOP 5 DRONES BY FLIGHT HOURS");
            var top5Hours = good.OrderByDescending(d => d.flightHours).Select(d => new { serialNumber = d.serialNumber, model = d.model, hours = d.flightHours });
            foreach (var drone in top5Hours)
            {
                File.AppendText(prc.reportAnalysisFilePath, $"{drone.serialNumber} | {drone.model} | {drone.hours}");
            }
        }

    }
}