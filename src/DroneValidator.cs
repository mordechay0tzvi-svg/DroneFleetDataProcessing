namespace drones
{
    class DroneValidator
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
}