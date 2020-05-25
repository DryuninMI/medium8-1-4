using mediun8_1_4;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace mediun8_1_4.Models.Weapont
{
    public class Weapont
    {
        private Timer _reloadWeapontTimer;
        public string Name { get; }
        public float Cooldown { get; }
        public int Damage { get; }

        public Weapont(string name, int weapontDamage = 1, int weapontCooldown = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (weapontDamage < 1)
                throw new ArgumentOutOfRangeException(nameof(weapontDamage));

            if (weapontCooldown < 0)
                throw new ArgumentOutOfRangeException(nameof(weapontCooldown));

            Name = name;
            Damage = weapontDamage;
            Cooldown = weapontCooldown;

            _reloadWeapontTimer = new Timer(Cooldown);
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
            if (Cooldown != 0)
            {
                if (IsReloading())
                {
                    return false;
                }
                else
                {
                    _reloadWeapontTimer.Start();
                    return true;
                }
            }

            return false;
        }
    }
}
