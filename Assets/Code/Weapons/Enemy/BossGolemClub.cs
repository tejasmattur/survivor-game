using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGolemClub : BaseEnemyWeapon
{

	void Start() {
		setBasicConfigurations();
		weaponDamage = 2;
		_ridgidbody2D.velocity = transform.right * 8;
	}


}
