namespace drones
{
   class IdValidator : IValidate<int>
    {
        public bool Validate(int check)
        {
            return (check > 0);
        }
    }
    class SerialNumberValidator : IValidate<string>
    {
        public bool Validate(string check)
        {
            if (check.Count() != 7) {return false;}
            string s1 = check.Substring(0, 4);
            string s2 = check.Substring(4);
            if (s1 != "DR-") {return false;}
            if (!int.TryParse(s2, out int _)) {return false;}
            return true;
        }
    }
    class ModelValidator : IValidate<string>
    {
        private readonly List<string> validModels = new {"Falcon-X", "Raven-M", "SkyEye-2", "CargoBee", "Storm-4", "Scout-Lite"};
        public bool Validate(string check)
        {
            return validModels.Contains(check);
        }
    }
    class CategoryValidator : IValidate<string>
    {
        private readonly List<string> validCategories = new {"Recon", "Patrol", "Mapping", "Delivery", "Search"};
        public bool Validate(string check)
        {
            return validCategories.Contains(check);
        }
    }
    class BaseLocationValidator : IValidate<string>
    {
        private readonly List<string> validLocations = new {"North", "South", "Central", "East", "West"};
        public bool Validate(string check)
        {
            return validLocations.Contains(check);
        }
    }
    class FlightHoursValidator : IValidate<double>
    {
        public bool Validate(double check)
        {
            return (check > 3000 && check < 0);
        }
    }
    class BatteryHealthValidator : IValidate<int>
    {
        public bool Validate(int check)
        {
            return (check > 100 && check < 0);
        }
    }
    class MaxRangeValidator : IValidate<double>
    {
        public bool Validate(double check)
        {
            return (check > 150 && check < 0);
        }
    }
    class MissionsCompletedValidator : IValidate<int>
    {
        public bool Validate(int check)
        {
            return (check > 5000 && check < 0);
        }
    }
    class StatusValidator : IValidate<string>
    {
        private readonly List<string> validStatus = new {"Operational", "Maintenance", "Grounded", "Training"};
        public bool Validate(string check)
        {
            return validStatus.Contains(check);
        }
    }
}