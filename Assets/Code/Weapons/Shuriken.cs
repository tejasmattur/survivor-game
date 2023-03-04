using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        weaponDamage = 1.5f;
        setBasicConfigurations();
        _ridgidbody2D.velocity = transform.right * 11;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
