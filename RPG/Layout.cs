using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Layout
    {
        public string HealthBar(float health, float maxHealth, bool alive)
        {
            string s;
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
