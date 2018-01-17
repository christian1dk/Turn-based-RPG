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
        private Wizzard wizzard;
        private Warrior warrior;
        private Layout layout = new Layout();
        private bool complete = false;
        private List<Enemy> enemys = new List<Enemy>();
        Random random = new Random();
        int enemyAlive;
        int enemysnr;

        public Arena(Wizzard wizzard, int difficulty)
        {
            this.wizzard = wizzard;
            this.difficulty = difficulty;
        }

        public Arena(Warrior warrior, int difficulty)
        {
            this.warrior = warrior;
            this.difficulty = difficulty;
        }

        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public void Setup(int difficulty)
        {
            if (warrior != null)
            {
                level = warrior.Level;
            }
            else if (wizzard != null)
            {
                level = wizzard.Level;
            }

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
            if (warrior != null)
            {
                if(warrior.Alive())
                {
                    warrior.AttackDamage(enemy);
                }
                else
                {
                    complete = true;
                }
            }
            else if (wizzard != null)
            {
                if (wizzard.Alive())
                {
                    wizzard.AttackDamage(enemy);
                }
                else
                {
                    complete = true;
                }
            }
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine("-------------- Arena -------------- ");
            Console.WriteLine("Health Bar: \n");

            if (warrior != null)
            {
                Console.WriteLine("{0} {1}", warrior.Name, layout.HealthBar(warrior.Health, warrior.MaxHealth, warrior.Alive()));
            }
            else if (wizzard != null)
            {
                Console.WriteLine("{0} {1}", wizzard.Name, layout.HealthBar(wizzard.Health, wizzard.MaxHealth, wizzard.Alive()));
            }

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
                        if (warrior != null)
                        {
                            enemy.AttackDamage(warrior);
                        }
                        else if (wizzard != null)
                        {
                            enemy.AttackDamage(wizzard);
                        }
                    }
                    else
                    {
                        enemyAlive--;
                        if (enemyAlive <= 0)
                        {
                            complete = true;
                            Console.WriteLine("Done");
                            break;
                        }
                    }
                }
                
            }
        }
    }
}
