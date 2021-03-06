﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    abstract class Enemy : Charater
    {
        private float xpReward;

        public float XpReward
        {
            get { return xpReward; }
            set { xpReward = value; }
        }
        public abstract AttackType SkillSelect();
    }
}
