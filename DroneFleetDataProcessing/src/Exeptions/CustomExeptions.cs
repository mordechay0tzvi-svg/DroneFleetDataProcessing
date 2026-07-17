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
    class EmptyJsonFile : Exception
    {
        public EmptyJsonFile(string message)
           : base(message) { }
    }

    class MalformedJsonException : Exception
    {
        public MalformedJsonException(string message)
            : base(message) { }
    }

   

    class DronsInvalidException : Exception
    {
        public DronsInvalidException(string message)
           : base(message) { }
    }
}
