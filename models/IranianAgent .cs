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
        protected List<Sensor> matchedSensors = new List<Sensor>();


        public abstract string Rank { get; }

        public IranianAgent(int numberOfSensors)
        {
            List<string> availableTypes = SensorFactory.GetAvailableSensorTypes();

            var rnd = new Random();
            for (int i = 0; i < numberOfSensors; i++)
            {
                string randomType = availableTypes[rnd.Next(availableTypes.Count)];
                weaknesses.Add(randomType);
                Console.WriteLine(randomType);
            }
        }

        public void AttachSensor(Sensor sensor)
        {
            attachedSensors.Add(sensor);
        }

        public int CheckMatch()
        {
            matchedSensors = new List<Sensor>();
            var remainingWeaknesses = new List<string>(weaknesses);

            foreach (Sensor sensor in attachedSensors)
            {
                if (!sensor.Activate())
                    continue;

                if (remainingWeaknesses.Contains(sensor.Type))
                    matchedSensors.Add(sensor);
                    remainingWeaknesses.Remove(sensor.Type);
            }

            return matchedSensors.Count;
        }

        public abstract int Counterattack();

        public int WeaknessCount => weaknesses.Count;

        public bool IsExposed() => matchedSensors.Count >= WeaknessCount;

    }

}
