namespace drones
{
    public interface IValidate
    {
        bool Validate(var variable);
        bool Validate(Drone drone);
        bool Validate(var variable, List<string> valids);
    }
    class DroneValidator : IValidate
    {
        List<string> validModels = new {"Falcon-X", "Raven-M", "SkyEye-2","CargoBee", "Storm-4", "Scout-Lite"};
        List<string> validCategories = new {"Recon", "Patrol", "Mapping","Delivery", "Search"};
        List<string> validLocations = new {"North", "South", "Central","East", "West"};
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
        public bool Validate(string model, List<string> models)
        {
            return models.Contains(model);
        }
    }
    class CategoryValidator : IValidate
    {
        public bool Validate(string category, List<string> categories)
        {
            return categories.Contains(category);
        }
    }
    class BaseLocationValidator : IValidate
    {
        public bool Validate(string location, List<string> locations)
        {
            return locations.Contains(location);
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
        public bool Validate()
        {
            
        }
    }
}