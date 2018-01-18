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

        public float Xp
        {
            get { return xp; }
            set { xp = value; }
        }

        public int[] LevelUp
        {
            get { return levelUp; }
            set { levelUp = value; }
        }

        public abstract void LevelUpStats();

        public abstract bool LevelUpCheck();
        public abstract int NextLevelUp();
        public abstract int LastLevelUp();
    }
}
