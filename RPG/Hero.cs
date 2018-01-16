using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    abstract class Hero : Charater
    {
        private float xp;
        private int[] levelUp = {100, 500, 1500, 3200, 4000, 4900, 5900, 7000, 8200, 9500 };

        public int LevelUp(float a)
        {
            return 1;
        }

        public bool LevelUpCheck(float a)
        {
            return false;
        }
    }
}
