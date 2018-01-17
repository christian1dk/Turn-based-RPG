using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Arena
    {
        private int difficulty;
        private int level;
        private Wizzard wizzard;
        private List<Enemy> enemys = new List<Enemy>();

        public Arena(Wizzard wizzard)
        {
            this.wizzard = wizzard;
        }

        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public void Setup(int difficulty)
        {
            level = wizzard.Level;

            if (difficulty == 1)
            {
                Goblin goblin1 = new Goblin(level);
                enemys.Add(goblin1);
            }
            else if (difficulty == 2)
            {
                Goblin goblin1 = new Goblin(level);
                Goblin goblin2 = new Goblin(level);
                enemys.Add(goblin1);
                enemys.Add(goblin2);
            }
            else if (difficulty == 3)
            {
                Goblin goblin1 = new Goblin(level);
                Goblin goblin2 = new Goblin(level);
                Goblin goblin3 = new Goblin(level);
                enemys.Add(goblin1);
                enemys.Add(goblin2);
                enemys.Add(goblin3);
            }
        }
    }
}
