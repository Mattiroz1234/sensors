using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.sensors
{
    internal class PulseSensor : Sensor, IBreakableSensor
    {
        public int MaxUsages => 3;
        public int ActivationCount { get; private set; } = 0;

        public override string Type => "pulse";

        public override bool IsBroken => ActivationCount >= MaxUsages;

        public override bool Activate()
        {
            if (IsBroken)
            {
                Console.WriteLine("Pulse Sensor is broken");
                return false;
            }
            else
            {
                ActivationCount++;
                return true;
            }
        }
    }

}
