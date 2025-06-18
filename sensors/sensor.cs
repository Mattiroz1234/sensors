using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal abstract class Sensor
    {
        public abstract string Type { get; }

        public abstract bool IsBroken { get; }

        public abstract bool Activate();

        

        
    }

}
