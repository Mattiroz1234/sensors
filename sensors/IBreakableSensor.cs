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
        bool IsBroken { get; }
        int ActivationCount { get; }
    }
}
