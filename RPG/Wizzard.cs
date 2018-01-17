using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Wizzard : Hero
    {
        public Wizzard(string name, AttackType type)
        {
            this.Name = name;
            this.Type = type;
            this.MaxHealth = 5000;
            this.Health = MaxHealth;
            this.Attack = 200;
            this.Defense = 50;
            this.Armor = 50;
            this.Level = 1;
            this.Xp = 4000;
        }

        public override bool Alive()
        {
            return (Health > 0);
        }

        public override bool LevelUpCheck()
        {
            for(int i = 0; i <= LevelUp.Length; i++)
            {
                if (Xp >= LevelUp[i])
                {
                    if (Level < i + 1)
                    {
                        return true;
                    }
                }
            }
            return false;
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

        public override void AttackDamage(Enemy enemy)
        {
            Damage = Random.Next((int)(Attack-(10*(0.1*Level+1))), (int)(Attack + (10 * (0.1 * Level + 1))));
            Console.WriteLine("Player Attack");
            enemy.Defend(Damage);
        }

        public override float AttackDamage(float a, int b)
        {
            throw new NotImplementedException();
        }

        public override float AttackDamage(float a, int b, AttackType c)
        {
            throw new NotImplementedException();
        }

        public override bool CriticalHitChance()
        {
            throw new NotImplementedException();
        }

        public override void Defend(float damage)
        {
            Health -= damage;
        }

        public override float Defend(float a, int b)
        {
            throw new NotImplementedException();
        }

        public override float Defend(float a, int b, AttackType c)
        {
            throw new NotImplementedException();
        }
    }
}
