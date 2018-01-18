using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Warrior : Hero
    {

        public Warrior(string name, AttackType type)
        {
            this.Name = name;
            this.Type = type;
            this.MaxHealth = 200;
            this.Health = MaxHealth;
            this.Attack = 10;
            this.Armor = 50;
            this.Defense = 50;
            this.CriticalHitChance = 5;
            this.Level = 1;
            this.Xp = 0;
        }

        public override bool Alive()
        {
            return (Health > 0);
        }

        public override bool LevelUpCheck()
        {
            for (int i = 0; i < LevelUp.Length; i++)
            {
                if (Xp >= LevelUp[i])
                {
                    if (Level < LevelUp[i + 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override int NextLevelUp()
        {
            for (int i = 0; i <= LevelUp.Length; i++)
            {
                if (Xp <= LevelUp[i])
                {
                    return LevelUp[i];
                }
            }
            return 0;
        }

        public override int LastLevelUp()
        {
            for (int i = 0; i <= LevelUp.Length; i++)
            {
                if (Xp <= LevelUp[i])
                {
                    try
                    {
                        return LevelUp[i - 1];
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public override void LevelUpStats()
        {
            Level++;
            MaxHealth *= 1.2f;
            Health = MaxHealth;
            Attack *= 1.2f;
            Defense *= 1.2f;
            Armor *= 1.2f;
        }

        public override void AttackDamage(Charater enemy)
        {
            Damage = Random.Next((int)(Attack - (5 * (0.1 * Level + 1))), (int)(Attack + (5 * (0.1 * Level + 1))));
            Console.WriteLine("Warrior Attack with {0} damage", Damage);
            enemy.Defend(Damage);
        }

        public override void AttackDamage(Charater enemy, int b, AttackType c)
        {
            throw new NotImplementedException();
        }

        public override bool CriticalHit()
        {
            throw new NotImplementedException();
        }

        public override void Defend(float damage)
        {
            Hit = Random.Next((int)(damage - (Defense + ((0.1 * Level))) / 2), (int)(damage - (Defense - ((0.1 * Level))) / 2));
            if (Hit > 0)
            {
                Health -= Hit;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warrior was hit and lost {0} health", Hit);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Warrior blocks the attack");
            }
        }

        public override float Defend(float damagea, int turns, AttackType c)
        {
            throw new NotImplementedException();
        }
    }
}
