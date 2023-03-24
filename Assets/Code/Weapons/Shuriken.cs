using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : BaseWeapon
{
    public Shuriken(float damage, int level) : base(damage, level)
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        setBasicConfigurations();
        _ridgidbody2D.velocity = transform.right * 11;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
