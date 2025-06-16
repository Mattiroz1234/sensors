using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                default:
                    Console.WriteLine($"Unknown sensor type: {type}. Please try again.");
                    return null;

            }
        }
    }
}
