namespace drones
{
    public class Drone
    {
        public int Id { get; }
        public string SerialNumber { get; }
        public string Model { get; }
        public string Category { get; }
        public string BaseLocation { get; }
        public double FlightHours { get; }
        public int BatteryHealth { get; }
        public double MaxRangeKm { get; }
        public int MissionsCompleted { get; }
        public string Status { get; }
    }
    public interface IValidate
    {
        bool Validate(object value);
    }
    class DroneValidator : IValidate
    {
        IdValidator idValidate = new();
        SerialNumberValidator serialNumberValidator = new();
        ModelValidator modelValidator = new();
        CategoryValidator categoryValidator = new();
        BaseLocationValidator baseLocationValidator = new();
        FlightHoursValidator flightHoursValidator = new();
        BatteryHealthValidator batteryHealthValidator = new();
        MaxRangeValidator maxRangeValidator = new();
        MissionsCompletedValidator missionsCompletedValidator = new();
        StatusValidator statusValidator = new();
        public bool Validate(Drone drone)
        {
            bool valid = true;
            valid &= idValidate.Validate(drone.Id);
            valid &= serialNumberValidator.Validate(drone.SerialNumber);
            valid &= modelValidator.Validate(drone.Model);
            valid &= categoryValidator.Validate(drone.Category);
            valid &= baseLocationValidator.Validate(drone.BaseLocation);
            valid &= flightHoursValidator.Validate(drone.FlightHours);
            valid &= batteryHealthValidator.Validate(drone.BatteryHealth);
            valid &= maxRangeValidator.Validate(drone.MaxRangeKm);
            valid &= missionsCompletedValidator.Validate(drone.MissionsCompleted);
            valid &= statusValidator.Validate(drone.Status);
            return valid;
        }
    }
    class IdValidator : IValidate
    {
        public bool Validate(int id)
        {
            return (id > 0);
        }
    }
    class SerialNumberValidator : IValidate
    {
        public bool Validate(string serialNumber)
        {
            if (serialNumber.Count() != 7) {return false;}
            string s1 = serialNumber.Substring(0, 4);
            string s2 = serialNumber.Substring(4);
            if (s1 != "DR-") {return false;}
            if (!int.TryParse(s2, out int _)) {return false;}
            return true;
        }
    }
    class ModelValidator : IValidate
    {
        private readonly List<string> validModels = new {"Falcon-X", "Raven-M", "SkyEye-2", "CargoBee", "Storm-4", "Scout-Lite"};
        public bool Validate(string model)
        {
            return validModels.Contains(model);
        }
    }
    class CategoryValidator : IValidate
    {
        private readonly List<string> validCategories = new {"Recon", "Patrol", "Mapping", "Delivery", "Search"};
        public bool Validate(string category)
        {
            return validCategories.Contains(category);
        }
    }
    class BaseLocationValidator : IValidate
    {
        private readonly List<string> validLocations = new {"North", "South", "Central", "East", "West"};
        public bool Validate(string location)
        {
            return validLocations.Contains(location);
        }
    }
    class FlightHoursValidator : IValidate
    {
        public bool Validate(double hours)
        {
            return (hours > 3000 && hours < 0);
        }
    }
    class BatteryHealthValidator : IValidate
    {
        public bool Validate(int percentage)
        {
            return (percentage > 100 && percentage < 0);
        }
    }
    class MaxRangeValidator : IValidate
    {
        public bool Validate(double km)
        {
            return (km > 150 && km < 0);
        }
    }
    class MissionsCompletedValidator : IValidate
    {
        public bool Validate(int amount)
        {
            return (amount > 5000 && amount < 0);
        }
    }
    class StatusValidator : IValidate
    {
        private readonly List<string> validStatus = new {"Operational", "Maintenance", "Grounded", "Training"};
        public bool Validate(string status)
        {
            return validStatus.Contains(status);
        }
    }
}