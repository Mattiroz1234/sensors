using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.main
{
    internal class SquadLeader: IranianAgent
    {
        public override string Rank => "Squad leader";

        public SquadLeader() : base(4) { }

        public override int Counterattack()
        {
            while (matchedSensors.Count() > 0) 
            {
                Random random = new Random();
                Sensor temp = attachedSensors[random.Next(attachedSensors.Count)];
                if (!temp.IsBroken && matchedSensors.Contains(temp))
                {
                    attachedSensors.Remove(temp);
                    Console.WriteLine("Squad leader hit back, one sensor removed.");
                    Console.WriteLine(temp.Type);
                    return 1;
                }
            }
            return 0;
        }
    }
}
