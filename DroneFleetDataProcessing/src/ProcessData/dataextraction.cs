using System.Data;

namespace drones
{
    class AllData()
    {
        public string cleanDronesFilePath;
        public string reportAnalysisFilePath;
        public List<Drone> all;
        public List<Drone> good;
        public AllData(string cleanDrones, string reportAnalysis, List<Drone> allDrones, List<Drone> goodDrones)
        {
            cleanDronesFilePath = cleanDrones;
            reportAnalysisFilePath = reportAnalysis;
            all = allDrones;
            good = goodDrones;
        }
        public void ShowDroneFile()
        {
            File.WriteAllText(cleanDronesFilePath, JsonSerializer.Serialize<List<Drone>>(prc.FilterDrones()));
        }
        public void ProcessingSummary()
        {
            File.AppendAllText(reportAnalysisFilePath, "DRONE FLEET ANALYSIS REPORT\n\n");
            File.AppendAllText(reportAnalysisFilePath, $"Total raw records: {all.Count}\n");
            File.AppendAllText(reportAnalysisFilePath, $"Valid records: {good.Count}\n");
            File.AppendAllText(reportAnalysisFilePath, $"Rejected records: {all.Count - good.Count}\n");
        }
        public void NoneOperationalDrones()
        {
            File.AppendAllText(reportAnalysisFilePath, "\n NON - OPERATIONAL DRONES \n");
            var nonOpDrone = good.Where(d => d.status != "Operational").Select(d => new { serialNumber = d.serialNumber, model = d.model, lbase = d.base_location, status = d.status });
            if (!nonOpDrone.Any()) { File.AppendAllText(reportAnalysisFilePath, "Non operational drone not found. \n"); return; }
            foreach (var drone in nonOpDrone)
            {
                File.AppendAllText(reportAnalysisFilePath, $"{drone.serialNumber} | {drone.model} | {drone.lbase} | {drone.status}\n");
            }
        }
        public void Top5Hours()
        {
            File.AppendAllText(reportAnalysisFilePath, "\n TOP 5 DRONES BY FLIGHT HOURS \n");
            var top5Hours = good.OrderByDescending(d => d.flightHours).Select(d => new { serialNumber = d.serialNumber, model = d.model, hours = d.flightHours }).Take(5);
            foreach (var drone in top5Hours)
            {
                File.AppendText(reportAnalysisFilePath, $"{drone.serialNumber} | {drone.model} | {drone.hours}\n");
            }
        }
        public void AvailableDroneModels()
        {
            File.AppendAllText(reportAnalysisFilePath, "\n AVAILABLE DRONE MODELS \n");
            var avialable = good.GroupBy(d => d.model).Select(d => new { model = d.Key });
            foreach (var model in avialable)
            {
                File.AppendAllText(reportAnalysisFilePath, $"{model.model}\n");
            }
        }
        public void DronesByBase()
        {
            File.AppendAllText(reportAnalysisFilePath, "\n DRONES BY BASE \n");
            var basesAmount = good.GroupBy(d => d.base_location).Select(b => new { basel = b.Key, c = b.Count() });
            foreach (var lbase in basesAmount)
            {
                File.AppendAllText(prc.reportAnalysisFilePath, $"{lbase.basel}: {lbase.c}\n");
            }
        }
        public void AvgBattery()
        {
            File.AppendAllText(reportAnalysisFilePath, "\n AVERAGE BATTERY HEALTH BY MODEL \n");
            var batteryHealth = good.GroupBy(d => d.model).Select(b => new { model = b.Key, avg = b.Average(b => b.batteryHealth) });
            foreach (var model in batteryHealth)
            {
                File.AppendAllText(reportAnalysisFilePath, $"{model.model}: {model.avg:F2}\n");
            }
        }
        public void MostMissionsModel()
        {
            File.AppendAllText(reportAnalysisFilePath, "\n MODEL WITH HIGHEST TOTAL COMPLETED MISSIONS \n");
            var missionModel = good.GroupBy(r => r.model).Select(r => new { model = r.Key, total = r.Sum(r => r.missionsCompleted) }).OrderByDescending(r => r.total).Take(1);
            foreach (var model in missionModel)
            {
                File.AppendAllText(reportAnalysisFilePath, $"{model.model}: {model.total}\n");
            }
        }
        public void Option1Select()
        {
            File.AppendAllText(reportAnalysisFilePath, "\n SELECTED ADDITIONAL ANALYSIS \n");
            var locations = good.Where(d => d.batteryHealth >= 80 && d.status == "Operational").GroupBy(r => r.base_location).Select(b => new { location = b.Key });
            foreach (var location in locations)
            {
                File.AppendAllText(reportAnalysisFilePath, $"{location.location}\n");
            }
        }

        public void GetReport()
        {
            ProcessingSummary();
            NoneOperationalDrones();
            Top5Hours();
            AvailableDroneModels();
            DronesByBase();
            AvgBattery();
            MostMissionsModel();
            Option1Select();
        }
    }
}