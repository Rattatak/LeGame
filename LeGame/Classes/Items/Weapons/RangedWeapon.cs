﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;

namespace LeGame.Classes.Items.Weapons
{
    abstract class RangedWeapon : IWeapon
    {
        public RangedWeapon(double damage, double range)
        {
            Damage = damage;
            Range = range;
        }

        public double Damage { get; set; }
        public double Range { get; set; }

        public abstract void Attack();
    }
}
