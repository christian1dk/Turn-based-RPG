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

        public string XpBar(float xp, int lastLevelUp, int nextLevelUp)
        {
            s = " Xp:[";
            int total = 20; //max # shown
            float count = (float)Math.Round(((xp - lastLevelUp) / (nextLevelUp - lastLevelUp)) * total); //Get the number of # to show
            if ((count == 0))
            {
                count = 1; //show at least one # if alive
            }
            for (int i = 0; i < count; i++)
            {
                s += "#";
            }
            s = s.PadRight(total + (int)((total - count) / 3)); //When we remove an #, the space between [ & ] will stay the same.  
            s += "]";

            return s;
        }

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
