using System.Security.Cryptography.X509Certificates;

namespace drones
{
    public interface IValidate
    {
        bool Validate(var variable);
        bool Validate(var variable, List<string> valids);
    }
    class DroneValidator : IValidate
    {
        List<string> validModels = new {"Falcon-X", "Raven-M", "SkyEye-2","CargoBee", "Storm-4", "Scout-Lite"};
        List<string> validCategories = new {"Recon", "Patrol", "Mapping","Delivery", "Search"};
        List<string> validLocations = new {"North", "South", "Central","East", "West"};
        IValidate idValidate = new();
        IValidate serialNumberValidator = new();
        IValidate modelValidator = new();
        IValidate categoryValidator = new();
        IValidate baseLocationValidator = new();
        IValidate flightHoursValidator = new();
        IValidate batteryHealthValidator = new();
        IValidate maxRangeValidator = new();
        IValidate missionsCompletedValidator = new();
        IValidate statusValidator = new();
        public bool Validate()
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
        public bool Validate()
        {
            
        }
    }
    class BatteryHealthValidator : IValidate
    {
        public bool Validate()
        {
            
        }
    }
    class MaxRangeValidator : IValidate
    {
        public bool Validate()
        {
            
        }
    }
    class MissionsCompletedValidator : IValidate
    {
        public bool Validate()
        {
            
        }
    }
    class StatusValidator : IValidate
    {
        public bool Validate()
        {
            
        }
    }
}