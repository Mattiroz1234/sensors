using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sensors.main;
using sensors.servis;

namespace sensors
{
    internal class Game
    {
        public static void StartGame()
        {
            List<string> AgentsExposed = new List<string>();
            IranianAgent agent = AgentServis.AgentMaker();
            Console.WriteLine("Agent captured. Try to uncover his weaknesses.");
            string a = AgentServis.Investigation(agent);
            AgentsExposed.Add(a);
        }
    }
}
