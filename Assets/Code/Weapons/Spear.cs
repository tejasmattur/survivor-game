using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : BaseWeapon
{
    public static Spear instance;

    public Spear(float damage, int level) : base(damage, level)
    {
    }

    private void Awake()
    {
        instance = this;
    }

    void Start() {
		setBasicConfigurations();
		_ridgidbody2D.velocity = transform.right * 10;
	}

}
