using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : UpgradeBase
{
    protected override void ApplyUpgrade()
    {
        Spear spear = FindObjectOfType<Spear>();
        spear.weaponDamage += 5;
    }
}

