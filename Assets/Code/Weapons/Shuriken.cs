using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : BaseWeapon
{
    void Start()
    {
        setBasicConfigurations();
        _ridgidbody2D.velocity = transform.right * 11 * weaponSpeedMultiplier;
    }

    void Update()
    {

    }
}
