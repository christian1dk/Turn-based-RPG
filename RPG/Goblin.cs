using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Goblin : Enemy
    {
        public Goblin(int level, int difficulty)
        {
            this.Name = "Goblin";
            this.Level = level;
            this.MaxHealth = 100 * (1.2f*Level);
            this.Health = MaxHealth;
            this.Attack = 10 * (1.2f * Level);
            this.Defense = 10 * (1.2f * Level);
            this.Armor = 10 * (1.2f * Level);
            this.CriticalHitChance = 5;
            this.XpReward = 10 * (1.2f * Level)*difficulty;
        }

        public override bool Alive()
        {
            return (Health > 0);
        }

        public override void AttackDamage(Charater hero)
        {
            Damage = Random.Next((int)(Attack - (5 * (0.1 * Level + 1))), (int)(Attack + (5 * (0.1 * Level + 1))));
            if (CriticalHit())
            {
                Damage *= 2;
            }
            Console.WriteLine("Goblin Attack with {0} damage", Damage);
            hero.Defend(Damage);
        }

        public override void AttackDamage(Charater hero, int a, AttackType c)
        {
            throw new NotImplementedException();
        }

        public override bool CriticalHit()
        {
            Number = Random.Next(1, 100);

            if (Number <= CriticalHitChance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Defend(float damage)
        {
            Hit = Random.Next((int)(damage - (Defense + ((0.1 * Level)))/2), (int)(damage - (Defense - ((0.1 * Level)))/2));
            if (Hit > 0)
            {
                Health -= Hit;
                Console.WriteLine("Goblin was hit and lost {0} health", Hit);
            }
            else
            {
                Console.WriteLine("Goblin blocks the attack");
            }
        }

        public override float Defend(float damage, int turns, AttackType c)
        {
            throw new NotImplementedException();
        }
    }
}
