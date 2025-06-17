using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal abstract class IranianAgent
    {
        protected List<string> weaknesses = new List<string>();
        protected List<Sensor> attachedSensors = new List<Sensor>();


        public abstract string Rank { get; }

        public IranianAgent(int numberOfSensors, List<string> availableTypes)
        {
            var rnd = new Random();
            for (int i = 0; i < numberOfSensors; i++)
            {
                string randomType = availableTypes[rnd.Next(availableTypes.Count)];
                weaknesses.Add(randomType);
            }
        }

        public virtual void AttachSensor(Sensor sensor)
        {
            attachedSensors.Add(sensor);
        }

        public int CheckMatch()
        {
            var temp = new List<string>(weaknesses);
            int matchCount = 0;

            foreach (var sensor in attachedSensors)
            {
                if (temp.Contains(sensor.Type))
                {
                    matchCount++;
                    temp.Remove(sensor.Type); 
                }
            }
            return matchCount;
        }

        public int WeaknessCount => weaknesses.Count;


        public bool IsExposed() => CheckMatch() == weaknesses.Count;

        //public virtual void OnTurnPassed(int turnNumber) { }
    }

}
