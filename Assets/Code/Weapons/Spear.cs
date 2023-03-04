using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : BaseWeapon
{
	void Start() {
		weaponDamage = 1;
		setBasicConfigurations();
		_ridgidbody2D.velocity = transform.right * 10;
	}
}
