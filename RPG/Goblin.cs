﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Goblin : Enemy
    {
        public Goblin(int level)
        {
            this.Name = "Goblin";
            this.Level = level;
            this.MaxHealth = 500 * (1.2f*Level);
            this.Health = MaxHealth;
            this.Attack = 200 * (1.2f * Level);
            this.Defense = 50 * (1.2f * Level);
            this.Armor = 50 * (1.2f * Level);
        }

        public override bool Alive()
        {
            return (Health > 0);
        }

        public override void AttackDamage(Hero hero)
        {
            Damage = Random.Next((int)(Attack - (10 * (0.1 * Level + 1))), (int)(Attack + (10 * (0.1 * Level + 1))));
            Console.WriteLine("Enemy Attack");
            hero.Defend(Damage);
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
