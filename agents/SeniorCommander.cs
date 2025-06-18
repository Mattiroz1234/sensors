using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.main
{
    internal class SeniorCommander: IranianAgent
    {
        public override string Rank => "Senior Commander";

        public SeniorCommander() : base(6) { }

        public override int Counterattack()
        {
            if (matchedSensors.Count < 2)
            {
                int temp = matchedSensors.Count;
                attachedSensors.Clear();
                return temp;
            }
            else
            {
                int cou = 0;
                while (true)
                {
                    Random random = new Random();
                    Sensor temp = attachedSensors[random.Next(attachedSensors.Count)];
                    if (!temp.IsBroken && matchedSensors.Contains(temp))
                    {
                        attachedSensors.Remove(temp);
                        Console.WriteLine("Squad leader hit back, one sensor removed.");
                        Console.WriteLine(temp.Type);
                        cou++;
                        if (cou == 2)
                            return cou;
                    }
                }
            }
        }
    }
}
