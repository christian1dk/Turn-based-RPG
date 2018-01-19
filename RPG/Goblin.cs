using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Goblin : Enemy
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="level">Goblin Level</param>
        /// <param name="difficulty"></param>
        public Goblin(int level, int difficulty)
        {
            this.Name = "Goblin";
            this.Level = level;
            this.MaxHealth = 100 * (1.2f*Level);
            this.Health = MaxHealth;
            this.Attack = 10 * (1.2f * Level);
            this.Defense = 10 * (1.2f * Level);
            this.Armor = 10 * (1.2f * Level);
            this.Chance = 5;
            this.Skill = SkillSelect();
            this.XpReward = 10 * (1.2f * Level)*difficulty;
        }

        /// <summary>
        /// Select Skill
        /// </summary>
        /// <returns>AttackType</returns>
        public override AttackType SkillSelect()
        {
            Number = Random.Next(1, 2 + 1);

            if (Number == 1)
            {
                return AttackType.Fire;
            }
            else if (Number == 2)
            {
                return AttackType.Ice;
            }
            else
            {
                return AttackType.Fire;
            }
        }

        /// <summary>
        /// Check if alive
        /// </summary>
        /// <returns>True or False</returns>
        public override bool Alive()
        {
            return (Health > 0);
        }

        /// <summary>
        /// Enemy Battle Action
        /// </summary>
        /// <param name="hero">Hero it's fighting</param>
        public override void Action(Charater hero)
        {
            if (InfectedTurns > 0)
            {
                Damage = Random.Next((int)((5 - (0.1 * Level + 1))), (int)((5 + (0.1 * Level + 1))));
                Console.WriteLine("Goblin took {0} fire damage", Damage);
                Defend(Damage);
                InfectedTurns--;
            }

            if (StunTurnes > 0)
            {
                StunTurnes--;
            }
            else
            {
                AttackDamage(hero);
            }
        }

        /// <summary>
        /// Ataack
        /// </summary>
        /// <param name="hero">Hero it's fighting</param>
        public override void AttackDamage(Charater hero)
        {
            Damage = Random.Next((int)(Attack - (5 * (0.1 * Level + 1))), (int)(Attack + (5 * (0.1 * Level + 1))));
            if (ChanceCheck())
            {
                Damage *= 2;
                Console.WriteLine("Goblin Critical Hit with {0} damage", Damage);
            }
            else
            {
                Console.WriteLine("Goblin Attack with {0} damage", Damage);
            }

            if (ChanceCheck())
            {

                AttackDamage(hero, Damage, TurnsNumber(), Skill);
            }
            else
            {
                hero.Defend(Damage);
            }
        }

        /// <summary>
        /// Attack With Skill
        /// </summary>
        /// <param name="hero">Hero it's fighting</param>
        /// <param name="damage">Damage to hero</param>
        /// <param name="turns">Turns for the skill effect</param>
        /// <param name="skill">Which Skill effect applied</param>
        public override void AttackDamage(Charater hero, float damage, int turns, AttackType skill)
        {
            Console.WriteLine("Goblin applied {0} for {1} turns", skill, turns);

            hero.Defend(damage, turns, skill);
        }

        /// <summary>
        /// Chance Check for Critical Hit & Skill
        /// </summary>
        /// <returns>True or False</returns>
        public override bool ChanceCheck()
        {
            Number = Random.Next(1, 100 +1);

            if (Number <= Chance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Skill effect turns
        /// </summary>
        /// <returns>Number of turns</returns>
        public override int TurnsNumber()
        {
            Number = Random.Next(1, 2 + 1);

            return Number;

        }

        /// <summary>
        /// Defend
        /// </summary>
        /// <param name="damage">damage dealt to enemy</param>
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

        /// <summary>
        /// Defend With Skill
        /// </summary>
        /// <param name="damage">Damage dealt from enemy</param>
        /// <param name="turns">Turns for the skill effect</param>
        /// <param name="skill">Which Skill effect applied</param>
        public override void Defend(float damage, int turns, AttackType skill)
        {
            Defend(damage);

            if(skill == AttackType.Fire)
            {
                InfectedTurns = turns;
                StunTurnes = 0;
            }
            else if (skill == AttackType.Ice)
            {
                StunTurnes = turns;
                InfectedTurns = 0;
            }

        }
    }
}
