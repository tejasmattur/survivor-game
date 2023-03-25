using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : BaseWeapon
{
    void Start()
    {
        setBasicConfigurations();
        _ridgidbody2D.velocity = transform.right * 10 * weaponSpeedMultiplier;
    }

    void Update()
    {

    }
}
