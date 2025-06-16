using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class ThermalSensor:Sensor
    {
        public override string Type => "thermal";

        public override bool IsBroken => false;

        public override bool Activate()
        {
            ActivationCount++;
            return true;
        }
    }
}
