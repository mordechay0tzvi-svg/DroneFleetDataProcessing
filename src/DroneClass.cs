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
    public interface IValidate<T>
    {
        bool Validate(T check);
    }
}