using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class AudioSensor : Sensor
    {
        public override string Type => "Audio";

        public override bool IsBroken => false;

        public override bool Activate()
        {
            ActivationCount++;
            return true;
        }
    }

}
