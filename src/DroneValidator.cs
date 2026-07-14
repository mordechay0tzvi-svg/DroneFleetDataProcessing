class DroneValidator : IValidate
    {
        List<string> validModels = new {"Falcon-X", "Raven-M", "SkyEye-2", "CargoBee", "Storm-4", "Scout-Lite"};
        List<string> validCategories = new {"Recon", "Patrol", "Mapping", "Delivery", "Search"};
        List<string> validLocations = new {"North", "South", "Central", "East", "West"};
        List<string> validStatus = new {"Operational", "Maintenance", "Grounded", "Training"};
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
            valid &= modelValidator.Validate(drone.Model, validModels);
            valid &= categoryValidator.Validate(drone.Category, validCategories);
            valid &= baseLocationValidator.Validate(drone.BaseLocation, validLocations);
            valid &= flightHoursValidator.Validate(drone.FlightHours);
            valid &= batteryHealthValidator.Validate(drone.BatteryHealth);
            valid &= maxRangeValidator.Validate(drone.MaxRangeKm);
            valid &= missionsCompletedValidator.Validate(drone.MissionsCompleted);
            valid &= statusValidator.Validate(drone.Status, validStatus);
            return valid;
        }
    }