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
