using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        weaponDamage = 3;
        setBasicConfigurations();
        _ridgidbody2D.velocity = transform.right * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
