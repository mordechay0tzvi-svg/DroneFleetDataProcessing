using Microsoft.VisualBasic.FileIO;

namespace drones
{
    class InvalidId : Exception;
    class InvalidSerialNumber : Exception;
    class InvalidModel : Exception;
    class InvalidCategory : Exception;
    class InvalidBaseLocation : Exception;
    class InvalidFlightHours : Exception;
    class InvalidBatteryHealth : Exception;
    class InvalidMaxRangeKm : Exception;
    class InvalidMissionsCompleted : Exception;
    class InvalidStatus : Exception;
    class NoValidDrones : Exception;
    class EmptyJsonFile : Exception
    {
        public EmptyJsonFile(string message)
           : base(message) { }
    }

    public class MalformedJsonException : Exception
    {
        public MalformedJsonException(string message, Exception innerException)
            : base(message,innerException) { }
    }

    public class JsonTypeMismatchException : Exception
    {
        public JsonTypeMismatchException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class drones_empty : Exception
    {
          
    }

    class CorruptJsonFile : Exception;

    class DronsInvalidException : Exception
    {
        public DronsInvalidException(string message)
           : base(message) { }
    }
}
