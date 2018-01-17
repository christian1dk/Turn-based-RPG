using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Warrior : Hero
    {

        public Warrior(string name)
        {
            this.Name = name;
            this.MaxHealth = 50;
            this.Health = MaxHealth;
            this.Attack = 200;
            this.Defense = 50;
            this.Armor = 50;
            this.Level = 1;
            this.Xp = 4000;
        }

        public override bool Alive()
        {
            throw new NotImplementedException();
        }

        public override void AttackDamage(Enemy enemy)
        {
            throw new NotImplementedException();
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

        public override float Defend(float a, int b)
        {
            throw new NotImplementedException();
        }

        public override void Defend(float a)
        {
            throw new NotImplementedException();
        }

        public override float Defend(float a, int b, AttackType c)
        {
            throw new NotImplementedException();
        }

        public override bool LevelUpCheck()
        {
            throw new NotImplementedException();
        }

        public override void LevelUpStats()
        {
            throw new NotImplementedException();
        }
    }
}
