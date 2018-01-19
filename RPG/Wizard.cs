using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Wizard : Hero
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="name">Wizzard Name</param>
        /// <param name="type">Wizzard Skill</param>
        public Wizard(string name, AttackType skill)
        {
            this.Name = name;
            this.Skill = skill;
            this.MaxHealth = 100;
            this.Health = MaxHealth;
            this.Attack = 30;
            this.Armor = 10;
            this.Defense = 10;
            this.Chance = 5;
            this.Level = 1;
            this.Xp = 0;
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
        /// Check if enough Xp to Level Up
        /// </summary>
        /// <returns>True or False</returns>
        public override bool LevelUpCheck()
        {
            for(int i = 0; i < LevelUp.Length; i++)
            {
                if (Xp >= LevelUp[i])
                {
                    if (Level < LevelUp[i+1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Next Level Up
        /// </summary>
        /// <returns>Xp to Next Level Up</returns>
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

        /// <summary>
        /// Last Level Up
        /// </summary>
        /// <returns>Xp from last Level Up</returns>
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

        /// <summary>
        /// Updating stats
        /// </summary>
        public override void LevelUpStats()
        {
            Level++;
            MaxHealth *= 1.2f;
            Health = MaxHealth;
            Attack *= 1.2f;
            Defense *= 1.2f;
            Armor *= 1.2f;
        }

        /// <summary>
        /// Player Battle Action
        /// </summary>
        /// <param name="enemy">Which enemy we are fighting</param>
        public override void Action(Charater enemy)
        {
            if (InfectedTurns > 0)
            {
                Hit = Random.Next((int)((5 - (0.1 * Level + 1))), (int)((5 + (0.1 * Level + 1))));
                Health -= Hit;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wizard took {0} fire damage", Hit);
                Console.ForegroundColor = ConsoleColor.White;
                InfectedTurns--;
            }

            if (StunTurnes > 0)
            {
                Console.WriteLine("Wizard is Frozen");
                StunTurnes--;
            }
            else
            {
                AttackDamage(enemy);
            }
        }

        /// <summary>
        /// Ataack
        /// </summary>
        /// <param name="enemy">Which enemy we are fighting</param>
        public override void AttackDamage(Charater enemy)
        {
            Damage = Random.Next((int)(Attack-(5*(0.1*Level+1))), (int)(Attack + (5 * (0.1 * Level + 1))));
            if (ChanceCheck())
            {
                Damage *= 2;
                Console.WriteLine("Wizard Critical Hit with {0} damage", Damage);
            }
            else
            {
                Console.WriteLine("Wizard Attack with {0} damage", Damage);
            }

            if (ChanceCheck())
            {

                AttackDamage(enemy, Damage, TurnsNumber(), Skill);
            }
            else
            {
                enemy.Defend(Damage);
            }
        }

        /// <summary>
        /// Attack With Skill
        /// </summary>
        /// <param name="enemy">Which enemy we are fighting</param>
        /// <param name="damage">Damage to enemy</param>
        /// <param name="turns">Turns for the skill effect</param>
        /// <param name="skill">Which Skill effect applied</param>
        public override void AttackDamage(Charater enemy, float damage, int turns, AttackType skill)
        {

            Console.WriteLine("Wizard applied {0} for {1} turns", skill, turns);

            enemy.Defend(damage, turns, skill);
        }

        /// <summary>
        /// Chance Check for Critical Hit & Skill
        /// </summary>
        /// <returns>True or False</returns>
        public override bool ChanceCheck()
        {
            Number = Random.Next(1, 100 + 1);

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
            Hit = Random.Next((int)(damage - (Defense + ((0.1 * Level)))/2), (int)(damage - (Defense - ((0.1 * Level))) / 2));
            if(Hit > 0)
            {
                Health -= Hit;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wizard was hit and lost {0} health", Hit);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Wizard blocks the attack");
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

            if (skill == AttackType.Fire)
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
