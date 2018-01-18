using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Input
    {
        private string name;
        private int playerSelect;
        private int heroSelect;
        private int attackTypeSelect;
        private AttackType attackType = AttackType.Fire;
        private Arena arena;
        private int difficulty;
        private Hero hero;
        private Layout layout = new Layout();

        public void CreatePlayer()
        {
            HeroSelect();

            HeroAttackType();

            HeroName();

            CreateHero();
        }

        public void Arena(int difficulty)
        {
            arena = new Arena(hero);
            arena.Setup(difficulty);
            arena.Run();
            PlayerMenu();
        }

        public void PlayerMenu()
        {
            Console.Clear();
            layout.PlayerInfo(hero.Health, hero.MaxHealth, hero.Alive(), hero.Level, hero.Xp, hero.LastLevelUp(), hero.NextLevelUp());


            Console.WriteLine();
            Console.WriteLine("-------------- Options -------------");
            Console.WriteLine("What do you want to do? (choose number)");
            Console.WriteLine("1. Arena");
            Console.WriteLine("2. Rest");
            PlayerOption();
            //playerSelect = Int16.Parse(Console.ReadLine());
        }

        public void PlayerOption()
        {
            try
            {
                playerSelect = Int16.Parse(Console.ReadLine());
            }
            catch
            {
                playerSelect = 0;
            }

            switch (playerSelect)
            {
                case 1:
                    ArenaDifficulty();
                    Arena(difficulty);
                    break;
                case 2:
                    hero.Health = hero.MaxHealth;
                    PlayerMenu();
                    break;
                default:
                    Console.WriteLine("You need to choose a Option");
                    PlayerOption();
                    break;
            }
        }

        public void HeroSelect()
        {
            //Hero select
            Console.WriteLine("What Hero do you want to play as? (choose number)");
            Console.WriteLine("1. Wizzard");
            Console.WriteLine("2. Warrior");

            try
            {
                heroSelect = Int16.Parse(Console.ReadLine());
            }
            catch
            {
                heroSelect = 0;
            }
        }      

        public void HeroAttackType()
        {
            //Hero AttackType
            Console.WriteLine("Whats your Heros AttackType? (choose number)");
            Console.WriteLine("1. Fire");
            Console.WriteLine("2. Ice");

            try
            {
                attackTypeSelect = Int16.Parse(Console.ReadLine());
            }
            catch
            {
                attackTypeSelect = 0;
            }

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
                    HeroAttackType();
                    break;
            }
        }

        public void HeroName()
        {
            //Player Name
            Console.WriteLine("Whats Your Hero Name?");
            name = Console.ReadLine();
        }

        public void CreateHero()
        {
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
                    HeroSelect();
                    CreateHero();
                    break;
            }
        }

        public void ArenaDifficulty()
        {
            Console.WriteLine("Difficulty? (1. Easy - 2. Normal - 3. Hard)");
            try
            {
                difficulty = Int16.Parse(Console.ReadLine());
            }
            catch
            {
                difficulty = 0;
            }

            if (!(difficulty >= 1 && difficulty <= 3))
            {
                ArenaDifficulty();
            }
        }
    }
}
