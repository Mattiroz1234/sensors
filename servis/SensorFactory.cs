using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sensors.sensors;

namespace sensors
{
    internal class SensorFactory
    {
        public static Sensor CreateSensor(string type)
        {
            switch (type.ToLower())
            {
                case "audio":
                    return new AudioSensor();

                case "thermal":
                    return new ThermalSensor();

                case "pulse":
                    return new PulseSensor();

                default:
                    Console.WriteLine($"Unknown sensor type: {type}. Please try again.");
                    return null;

            }
        }

        public static List<string> GetAvailableSensorTypes()
        {
            return new List<string> { "audio", "thermal", "pulse" };
        }
    }
}
