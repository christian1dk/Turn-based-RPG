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


        /// <summary>
        /// Creating Player
        /// </summary>
        public void CreatePlayer()
        {
            HeroSelect();

            HeroAttackSkill();

            HeroName();

            CreateHero();
        }

        /// <summary>
        /// Run Arena
        /// </summary>
        /// <param name="difficulty"></param>
        public void Arena(int difficulty)
        {
            arena = new Arena(hero);
            arena.Setup(difficulty);
            arena.Run();
            PlayerMenu();
        }

        /// <summary>
        /// Player Menu
        /// </summary>
        public void PlayerMenu()
        {
            Console.Clear();
            layout.PlayerInfo(hero.Health, hero.MaxHealth, hero.Alive(), hero.Level, hero.Xp, hero.LastLevelUp(), hero.NextLevelUp());


            Console.WriteLine();
            Console.WriteLine("-------------- Options -------------");
            Console.WriteLine("What do you want to do? (choose number)");
            if (hero.Alive())
            {
                Console.WriteLine("1. Arena");
                Console.WriteLine("2. Rest");
                PlayerOption();
            }
            Console.WriteLine("1. Restart");
            DeadOption();
            //playerSelect = Int16.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Player Options
        /// </summary>
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

        /// <summary>
        /// Dead Options
        /// </summary>
        public void DeadOption()
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
                    CreatePlayer();
                    PlayerMenu();
                    break;
                default:
                    Console.WriteLine("You need to choose a Option");
                    PlayerOption();
                    break;
            }
        }

        /// <summary>
        /// Select Hero
        /// </summary>
        public void HeroSelect()
        {
            //Hero select
            Console.WriteLine("What Hero do you want to play as? (choose number)");
            Console.WriteLine("1. Wizard");
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

        /// <summary>
        /// Hero Attack Skill
        /// </summary>
        public void HeroAttackSkill()
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
                    HeroAttackSkill();
                    break;
            }
        }

        public void HeroName()
        {
            //Player Name
            Console.WriteLine("Whats Your Hero Name?");
            name = Console.ReadLine();
        }

        /// <summary>
        /// Create Hero
        /// </summary>
        public void CreateHero()
        {
            switch (heroSelect)
            {
                case 1:
                    hero = new Wizard(name, attackType);
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

        /// <summary>
        /// Arena Difficulty
        /// </summary>
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
