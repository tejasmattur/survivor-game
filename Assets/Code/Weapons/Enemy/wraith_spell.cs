using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wraith_spell : BaseEnemyWeapon
{

	void Start() {
		setBasicConfigurations();
		weaponDamage = 1;
		_ridgidbody2D.velocity = transform.right * 8;
	}


}
