using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class FootSoldier: IranianAgent
    {
        public override string Rank => "Foot Soldier";

        public FootSoldier() : base(2) { }

        public override int Counterattack()
        {
            Console.WriteLine("Foot Soldier Can't attack back.");
            return 0;
        }
    }
}
