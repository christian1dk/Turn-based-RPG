using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        private static string name;
        private static int playerSelect;
        private static int heroSelect;
        private static int attackTypeSelect;
        private static AttackType attackType = AttackType.Fire;
        //private static Wizzard wizzard;
        //private static Warrior warrior;
        private static Arena arena;
        private static Layout layout = new Layout();
        private static int difficulty;
        private static Hero hero;

        static void Main(string[] args)
        {
            //Hero select
            Console.WriteLine("What Hero do you want to play as?");
            Console.WriteLine("1 Wizzard");
            Console.WriteLine("2 Warrior");

            heroSelect = Int16.Parse(Console.ReadLine());

            //Hero AttackType
            Console.WriteLine("Whats your Heros AttackType?");
            Console.WriteLine("1 Fire");
            Console.WriteLine("2 Ice");

            attackTypeSelect = Int16.Parse(Console.ReadLine());

            switch (attackTypeSelect)
            {
                case 1:
                    attackType = AttackType.Fire;
                    break;
                case 2:
                    attackType = AttackType.Ice;
                    break;
                default:
                    Console.WriteLine("You need to choose a Hero attackTypeSelect");
                    break;
            }

            //Player Name
            Console.WriteLine("Whats Your Hero Name?");
            name = Console.ReadLine();

            switch (heroSelect)
            {
                case 1:
                    hero = new Wizzard(name, attackType);
                    break;
                case 2:
                    hero = new Warrior(name, attackType);
                    break;
                default:
                    Console.WriteLine("You need to choose a Hero");
                    break;
            }

            Console.Clear();
            layout.PlayerInfo(hero.Health, hero.MaxHealth, hero.Alive(), hero.Level, hero.Xp, hero.LastLevelUp(), hero.NextLevelUp());


            Console.WriteLine("Options");
            Console.WriteLine("1 Arena");

            playerSelect = Int16.Parse(Console.ReadLine());

            switch (playerSelect)
            {
                case 1:
                    Console.WriteLine("Difficulty?");
                    difficulty = Int16.Parse(Console.ReadLine());
                    Arena(difficulty);
                    break;
                default:
                    Console.WriteLine("You need to choose a Option");
                    break;
            }


            //Arena arena = new Arena(wizzard, 1);

            //arena.Setup(2);
            //arena.Run();

            Console.ReadKey();
        }

        public static void Arena(int difficulty)
        {
            arena = new Arena(hero);
            arena.Setup(difficulty);
            arena.Run();
        }
    }
}
