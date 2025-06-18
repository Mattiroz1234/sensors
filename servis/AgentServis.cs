using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sensors.agents;
using sensors.main;

namespace sensors.servis
{
    internal class AgentServis
    {
        public static string Investigation(IranianAgent agent)
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
            return agent.Rank;
        }

        private static IranianAgent CreateAgent(string type)
        {
            switch (type)
            {
                case "Foot Soldier":
                    return new FootSoldier();

                case "Senior Commander":
                    return new SeniorCommander();

                case "Squad leader":
                    return new SquadLeader();

                case "Organization Leader":
                    return new OrganizationLeader();

                default:
                    return null;
            }
        }

        private static List<string> GetAgentTypes()
        {
            return new List<string> { "Foot Soldier", "Senior Commander", "Squad leader", "Organization Leader" };
        }

        public static IranianAgent AgentMaker()
        {
            List<string> agents = GetAgentTypes();

            var rnd = new Random();
            string randomType = agents[rnd.Next(agents.Count)];
            IranianAgent agent = CreateAgent(randomType);
            return agent;
        }
    }
}
