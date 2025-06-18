using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.sensors
{
    internal interface IBreakableSensor
    {
        int MaxUsages { get; }
        
        int ActivationCount { get; }
    }
}
