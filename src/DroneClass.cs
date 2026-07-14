namespace drones
{
    public class Drone
    {
        public int Id { get; set;}
        public required string SerialNumber { get; set;}
        public required string Model { get; set;}
        public required string Category { get; set;}
        public required string BaseLocation { get; set;}
        public required double FlightHours { get; set;}
        public required int BatteryHealth { get; set;}
        public required double MaxRangeKm { get; set;}
        public required int MissionsCompleted { get; set;}
        public required string Status { get; set;}
    }
    public interface IValidate<T>
    {
        bool Validate(T check);
    }
}