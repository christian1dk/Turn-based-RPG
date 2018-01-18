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
        private Hero hero;
        private Layout layout = new Layout();
        private bool complete = false;
        private List<Enemy> enemys = new List<Enemy>();
        Random random = new Random();
        int enemyAlive;
        int enemysnr;

        public Arena(Hero hero)
        {
            this.hero = hero;
        }

        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public void Setup(int difficulty)
        {
            level = hero.Level;

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

            enemyAlive = enemys.Count();
        }

        public void Attack(Enemy enemy)
        {
            if (hero.Alive())
            {
                hero.AttackDamage(enemy);
            }
            else
            {
                complete = true;
            }
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine("-------------- Arena -------------- ");
            Console.WriteLine("Health Bar: \n");

            Console.WriteLine("{0} {1}", hero.Name, layout.HealthBar(hero.Health, hero.MaxHealth, hero.Alive()));

            foreach (Enemy enemy in enemys)
            {
                Console.WriteLine("{0} {1}", enemy.Name, layout.HealthBar(enemy.Health, enemy.MaxHealth, enemy.Alive()));
                //Console.WriteLine("{0} {1}", enemy.Name, enemy.HealthBar());
            }

            Console.WriteLine();
        }

        public void Run()
        {
            while (complete == false)
            {
                Thread.Sleep(1000);
                Render();

                //We need to run random before we check alive status therefore do-while & not while.
                do
                {
                    enemysnr = random.Next(0, enemys.Count());
                }
                while (!enemys[enemysnr].Alive()); //We will only attack Enemy there is alive.

                Attack(enemys[enemysnr]);
                Console.WriteLine("enemy" + enemysnr);


                Thread.Sleep(1000);
                Render();
                enemyAlive = enemys.Count();

                foreach (Enemy enemy in enemys)
                {
                    if (enemy.Alive())
                    {
                        enemy.AttackDamage(hero);
                    }
                    else
                    {
                        enemyAlive--;
                        if (enemyAlive <= 0)
                        {
                            complete = true;
                            Console.WriteLine("Done");

                            /*if (wizzard.LevelUpCheck())
                            {
                                wizzard.LevelUpStats();
                            }*/
                            break;
                        }
                    }
                }
                
            }
        }
    }
}
