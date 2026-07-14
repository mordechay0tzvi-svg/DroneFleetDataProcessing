namespace drones
{
    public interface IValidate
    {
        bool Validate(var variable);
    }
    class DroneValidator : IValidate
    {
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
            return True;
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
            bool valid = true;
            if (serialNumber.Count() != 7) {valid = false;}
            string s1 = serialNumber.Substring(0, 4);
            string s2 = serialNumber.Substring(4);
            if (s1 != "DR-") {valid = false;}
            if (!int.TryParse(s2, out int _)) {valid = false;}
            return valid;
        }
    }
    class ModelValidator : IValidate
    {
        public bool Validate()
        {
            
        }
    }
    class CategoryValidator : IValidate
    {
        public bool Validate()
        {
            
        }
    }
    class BaseLocationValidator : IValidate
    {
        public bool Validate()
        {
            
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