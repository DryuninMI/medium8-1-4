using mediun8_1_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace mediun8_1_4.Models.Weapont
{
    public class Gun : IWeapont
    {
        private Timer _reloadWeapontTimer;
        public string Name { get; }
        public float WeaponCooldown { get; }
        public int WeaponDamage { get; }

        public Gun(string name, int weapontDamage = 1)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException();

            if (weapontDamage < 1)
                throw new InvalidOperationException();

            Name = name;
            WeaponDamage = weapontDamage;

            _reloadWeapontTimer = new Timer(10);
            _reloadWeapontTimer.Elapsed += ReloadWeapontTimer_Elapsed;
        }

        private void ReloadWeapontTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _reloadWeapontTimer.Stop();
        }

        public void Attack()
        {
            // Do attack
        }

        public bool IsReloading()
        {
            return _reloadWeapontTimer.Enabled;
        }

        public bool TryReload()
        {
            if(IsReloading())
            {
                return false;
            }
            else
            {
                _reloadWeapontTimer.Start();
                return true;
            }
        }
    }
}
