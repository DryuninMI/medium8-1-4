using System;
using System.Collections.Generic;
using System.Text;

namespace mediun8_1_4.Interfaces
{
    public interface IWeapont
    {
        string Name { get; }
        float WeaponCooldown { get; }
        int WeaponDamage { get; }

        void Attack();
        bool IsReloading();
        bool TryReload();
    }
}
