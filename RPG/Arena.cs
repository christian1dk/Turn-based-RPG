using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG
{
    class Arena
    {
        private int difficulty;
        private int level;
        private int enemyAlive;
        private int enemiesnr;
        private bool complete = false;
        private List<Enemy> enemies = new List<Enemy>();
        private Hero hero;
        private Layout layout = new Layout();
        private Random random = new Random();

        /// <summary>
        /// Hero Add to Arena
        /// </summary>
        /// <param name="hero"></param>
        public Arena(Hero hero)
        {
            this.hero = hero;
        }

        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        /// <summary>
        /// Creating the enemies
        /// </summary>
        /// <param name="difficulty">How difficulty the battle should be</param>
        public void Setup(int difficulty)
        {
            level = hero.Level;

            if (difficulty == 1)
            {
                Goblin goblin1 = new Goblin(level, difficulty);
                enemies.Add(goblin1);
            }
            else if (difficulty == 2)
            {
                Goblin goblin1 = new Goblin(level, difficulty);
                Goblin goblin2 = new Goblin(level, difficulty);
                enemies.Add(goblin1);
                enemies.Add(goblin2);
            }
            else if (difficulty == 3)
            {
                Goblin goblin1 = new Goblin(level, difficulty);
                Goblin goblin2 = new Goblin(level, difficulty);
                Goblin goblin3 = new Goblin(level, difficulty);
                enemies.Add(goblin1);
                enemies.Add(goblin2);
                enemies.Add(goblin3);
            }

            enemyAlive = enemies.Count();
        }

        /// <summary>
        /// Run the battle
        /// </summary>
        public void Run()
        {
            while (complete == false && hero.Alive())
            {
                Thread.Sleep(1000);
                layout.Arena(hero, enemies);

                //We need to run random before we check alive status therefore do-while & not while.
                do
                {
                    enemiesnr = random.Next(0, enemies.Count());
                }
                while (!enemies[enemiesnr].Alive()); //We will only attack Enemy there is alive.

                if (hero.Alive())
                {
                    hero.Action(enemies[enemiesnr]);
                }
                else
                {
                    complete = true;
                    break;
                }


                Thread.Sleep(1000);
                layout.Arena(hero, enemies);
                enemyAlive = enemies.Count();

                foreach (Enemy enemy in enemies)
                {
                    if (enemy.Alive())
                    {
                        enemy.Action(hero);
                    }
                    else
                    {
                        enemyAlive--;
                        if (enemyAlive <= 0)
                        {
                            foreach (Enemy deadEnemy in enemies)
                            {
                                hero.Xp += deadEnemy.XpReward;
                                if (hero.LevelUpCheck())
                                {
                                    hero.LevelUpStats();
                                }
                            }
                            complete = true;
                            break;
                        }
                    }
                }
                
            }
        }
    }
}
