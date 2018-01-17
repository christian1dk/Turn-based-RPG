using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizzard wizzard = new Wizzard("Christian", AttackType.Ice);
            Arena arena = new Arena(wizzard, 1);

            /*
            if (wizzard.Alive())
            {
                Console.WriteLine("Alive");
            }

            Console.WriteLine(wizzard.Health);

            Console.WriteLine(wizzard.Level);
            if(wizzard.LevelUpCheck())
            {
                wizzard.LevelUpStats();
            }
            Console.WriteLine(wizzard.Level);
            Console.WriteLine(wizzard.Health);
            if (wizzard.LevelUpCheck())
            {
                wizzard.LevelUpStats();
            }
            Console.WriteLine(wizzard.Level);
            Console.WriteLine(wizzard.Health);
            */

            arena.Setup(2);
            arena.Run();

            Console.ReadKey();
        }
    }
}
