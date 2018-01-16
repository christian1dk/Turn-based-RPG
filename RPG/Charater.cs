using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    abstract class Charater
    {
        private string name;
        private float health;
        private float attack;
        private float defence;
        private float armor;
        private int level;
        private AttackType type;
        protected int stunTurnes;

        public abstract float Attack(float a, int b);
        public abstract float Attack(float a, int b, AttackType c);
        public abstract float Defence(float a, int b);
        public abstract float Defence(float a, int b, AttackType c);
        public abstract bool CriticalHitChance();
    }

    enum AttackType { Fire, Ice}
}
