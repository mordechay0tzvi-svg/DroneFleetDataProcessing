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
            valid &= idValidate.Validate(drone.id);
            valid &= serialNumberValidator.Validate(drone.serialNumber);
            valid &= modelValidator.Validate(drone.model);
            valid &= categoryValidator.Validate(drone.category);
            valid &= baseLocationValidator.Validate(drone.base_location);
            valid &= flightHoursValidator.Validate(drone.flightHours);
            valid &= batteryHealthValidator.Validate(drone.batteryHealth);
            valid &= maxRangeValidator.Validate(drone.maxRangeKm);
            valid &= missionsCompletedValidator.Validate(drone.missionsCompleted);
            valid &= statusValidator.Validate(drone.status);
            return valid;
        }
    }
}