using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sensors.main;

namespace sensors
{
    internal class Game
    {
        public static void StartGame()
        {
            IranianAgent agent = new SeniorCommander();
            Console.WriteLine("Agent captured. Try to uncover his weaknesses.");
            Investigation(agent);
        }


        public static void Investigation(IranianAgent agent)
        {
            int totalNeeded = agent.WeaknessCount;
            var availableSensors = SensorFactory.GetAvailableSensorTypes();
            int turn = 0;

            while (!agent.IsExposed())
            {
                turn++;
                Console.WriteLine($"\nTurn: {turn}");
                Console.WriteLine("Available sensors: " + string.Join(", ", availableSensors));
                Console.Write("Enter sensor type: ");
                string input = Console.ReadLine();

                Sensor sensor = SensorFactory.CreateSensor(input);
                if (sensor == null)
                {
                    Console.WriteLine("Invalid sensor type.");
                    turn--;
                    continue;
                }

                agent.AttachSensor(sensor);
                int match = agent.CheckMatch();
                Console.WriteLine($"Matching sensors: {match}/{totalNeeded}");

                if (turn % 3 == 0 && match != totalNeeded)
                {
                    int remuvedSensors = agent.Counterattack();
                    Console.WriteLine($"Matching sensors: {match - remuvedSensors}/{totalNeeded}");
                }
            }

            Console.WriteLine("Agent exposed successfully!");
        }

    }
}
