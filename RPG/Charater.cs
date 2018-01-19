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
        private float maxHealth;
        private float damage;
        private float attack;
        private float defense;
        private float armor;
        private float hit;
        private int level;
        private int number;
        private int chance;
        private int infectedTurns;
        private int stunTurnes;
        private AttackType skill;
        private Random random = new Random();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        public float MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        public float Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public float Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public float Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public float Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public float Hit
        {
            get { return hit; }
            set { hit = value; }
        }

        public int Chance
        {
            get { return chance; }
            set { chance = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public int InfectedTurns
        {
            get { return infectedTurns; }
            set { infectedTurns = value; }
        }

        public int StunTurnes
        {
            get { return stunTurnes; }
            set { stunTurnes = value; }
        }

        public AttackType Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        public Random Random
        {
            get { return random; }
            set { random = value; }
        }

        public abstract bool Alive();
        public abstract void Action(Charater charater);
        public abstract void AttackDamage(Charater charater);
        public abstract void AttackDamage(Charater charater, float damage, int turns, AttackType skill);
        public abstract void Defend(float damage);
        public abstract void Defend(float damage, int turns, AttackType skill);
        public abstract bool ChanceCheck();
        public abstract int TurnsNumber();
    }

    enum AttackType { Fire, Ice}
}
