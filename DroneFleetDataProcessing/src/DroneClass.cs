namespace drones
{
    public class Drone
    {
        public int id { get; set;}
        public required string serialNumber { get; set;}
        public required string model { get; set;}
        public required string category { get; set;}
        public required string base_location { get; set;}
        public double flightHours { get; set;}
        public int batteryHealth { get; set;}
        public double maxRangeKm { get; set;}
        public int missionsCompleted { get; set;}
        public required string status { get; set;}
    }
    public interface IValidate<T>
    {
        bool Validate(T check);
    }
}