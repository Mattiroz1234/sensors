using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class Game
    {
        public static void StartGame()
        {
            IranianAgent agent = new FootSoldier();
            Console.WriteLine("Agent captured. Try to uncover his weaknesses.");

            int totalNeeded = agent.WeaknessCount;

            var availableSensors = SensorFactory.GetAvailableSensorTypes();

            while (!agent.IsExposed())
            {
                Console.WriteLine("Available sensors: " + string.Join(", ", availableSensors));
                Console.Write("Enter sensor type: ");
                string input = Console.ReadLine().ToLower();

                Sensor sensor = SensorFactory.CreateSensor(input);
                if (sensor == null)
                {
                    Console.WriteLine("Invalid sensor type.");
                    continue;
                }

                agent.AttachSensor(sensor);
                int match = agent.CheckMatch();
                Console.WriteLine($"Matching sensors: {match}/{totalNeeded}");
            }

            Console.WriteLine("Agent exposed successfully!");
        }

    }
}
