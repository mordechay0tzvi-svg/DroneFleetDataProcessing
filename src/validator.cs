namespace drones
{
    public interface IValidate
    {
        bool Validate(var variable);
    }
    class DroneValidator : IValidate
    {
        public bool Validate()
        {
            return True;
        }
    }
    class IdValidator : IValidate
    {
        public bool Validate(int id)
        {
            
        }
    }
    
    class SerialNumberValidator : IValidate
    {
        public bool Validate()
        {
            
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