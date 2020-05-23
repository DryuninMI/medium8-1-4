using mediun8_1_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace mediun8_1_4.Models.Weapont
{
    class Fists : IWeapont
    {
        public string Name { get; }
        public float WeaponCooldown { get; }
        public int WeaponDamage { get; }

        public Fists()
        {
            Name = "Fists";
            WeaponCooldown = 1.0f;
            WeaponDamage = 1;
        }

        public void Attack()
        {
            // Do attack
        }

        public bool IsReloading()
        {
            return false;
        }

        public bool TryReload()
        {
            return false;
        }
    }
}
