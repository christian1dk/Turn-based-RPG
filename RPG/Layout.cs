using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Layout
    {
        string s;

        /// <summary>
        /// Player Info
        /// </summary>
        /// <param name="health">Player Health</param>
        /// <param name="maxHealth">Player Max Health</param>
        /// <param name="alive">Is Player Alive</param>
        /// <param name="level">Player Level</param>
        /// <param name="xp">Player Xp</param>
        /// <param name="lastLevelUp">Xp from last Level Up</param>
        /// <param name="nextLevelUp">Xp to Next Level Up</param>
        /// <returns>Player Info Layout</returns>
        public string PlayerInfo(float health, float maxHealth, bool alive, int level, float xp, int lastLevelUp, int nextLevelUp)
        {
            if (alive)
            { 
                Console.WriteLine("-------------- Player -------------- ");
                Console.WriteLine("Health: " + (int)health + "/" + (int)maxHealth);
            }
            else
            {
                Console.WriteLine("-------------- Dead -------------- ");
            }
            Console.WriteLine("Level: " + level + XpBar(xp, lastLevelUp, nextLevelUp));


            return s;
        }

        /// <summary>
        /// XpBar
        /// </summary>
        /// <param name="xp">Player Xp</param>
        /// <param name="lastLevelUp">Xp from last Level Up</param>
        /// <param name="nextLevelUp">Xp to Next Level Up</param>
        /// <returns>XpBar Layout</returns>
        public string XpBar(float xp, int lastLevelUp, int nextLevelUp)
        {
            s = " Xp:[";
            int total = 20; //max # shown
            float count = (float)Math.Round(((xp - lastLevelUp) / (nextLevelUp - lastLevelUp)) * total); //Get the number of # to show
            for (int i = 0; i < count; i++)
            {
                s += "#";
            }
            s = s.PadRight(total + (int)((total - count) / 3)); //When we remove an #, the space between [ & ] will stay the same.  
            s += "]";

            return s;
        }

        /// <summary>
        /// Arena Layout
        /// </summary>
        /// <param name="hero">Hero In Arena</param>
        /// <param name="enemies">enemies In Arena</param>
        public void Arena(Hero hero, List<Enemy> enemies)
        {
            Console.Clear();
            Console.WriteLine("-------------- Arena -------------- ");
            Console.WriteLine("Health Bar: \n");

            Console.WriteLine("{0} {1}", hero.Name, HealthBar(hero.Health, hero.MaxHealth, hero.Alive()));

            foreach (Enemy enemy in enemies)
            {
                Console.WriteLine("{0} {1}", enemy.Name, HealthBar(enemy.Health, enemy.MaxHealth, enemy.Alive()));
                //Console.WriteLine("{0} {1}", enemy.Name, enemy.HealthBar());
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Health Bar
        /// </summary>
        /// <param name="health">Health</param>
        /// <param name="maxHealth">Max Health</param>
        /// <param name="alive">Is alive</param>
        /// <returns>Health Bar Layout</returns>
        public string HealthBar(float health, float maxHealth, bool alive)
        {
            if (alive)
            {
                s = "[";
                int total = 20; //max # shown
                float count = (float)Math.Round((health / maxHealth) * total); //Get the number of # to show
                if ((count == 0))
                {
                    count = 1; //show at least one # if alive
                }
                for (int i = 0; i < count; i++)
                {
                    s += "#";
                }
                s = s.PadRight(total + 1); //When we remove an #, the space between [ & ] will stay the same.  
                s += "]";
            }
            else
            {
                s = "[        Dead        ]";
            }

            return s;
        }
    }
}
