namespace drones
{
   class IdValidator : IValidate<int>
    {
        public bool Validate(int id)
        {
            return (id > 0);
        }
    }
    class SerialNumberValidator : IValidate<string>
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
    class ModelValidator : IValidate<string>
    {
        private readonly List<string> validModels = new {"Falcon-X", "Raven-M", "SkyEye-2", "CargoBee", "Storm-4", "Scout-Lite"};
        public bool Validate(string model)
        {
            return validModels.Contains(model);
        }
    }
    class CategoryValidator : IValidate<string>
    {
        private readonly List<string> validCategories = new {"Recon", "Patrol", "Mapping", "Delivery", "Search"};
        public bool Validate(string category, List<string> categories)
        {
            return validCategories.Contains(category);
        }
    }
    class BaseLocationValidator : IValidate<string>
    {
        List<string> validLocations = new {"North", "South", "Central", "East", "West"};
        private readonly 
        public bool Validate(string location, List<string> locations)
        {
            return validLocations.Contains(location);
        }
    }
    class FlightHoursValidator : IValidate<double>
    {
        public bool Validate(double hours)
        {
            return (hours > 3000 && hours < 0);
        }
    }
    class BatteryHealthValidator : IValidate<int>
    {
        public bool Validate(int percentage)
        {
            return (percentage > 100 && percentage < 0);
        }
    }
    class MaxRangeValidator : IValidate<double>
    {
        public bool Validate(double km)
        {
            return (km > 150 && km < 0);
        }
    }
    class MissionsCompletedValidator : IValidate<int>
    {
        public bool Validate(int amount)
        {
            return (amount > 5000 && amount < 0);
        }
    }
    class StatusValidator : IValidate<string>
    {
        private readonly List<string> validStatus = new {"Operational", "Maintenance", "Grounded", "Training"};
        public bool Validate(string status, List<string> statusList)
        {
            return validStatus.Contains(status);
        }
    }
}