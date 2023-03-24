using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : BaseWeapon
{
    public Kunai(float damage, int level) : base(damage, level)
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        setBasicConfigurations();
        _ridgidbody2D.velocity = transform.right * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
