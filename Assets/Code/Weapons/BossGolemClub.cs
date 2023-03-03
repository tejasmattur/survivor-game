using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGolemClub : MonoBehaviour
{
	int collisonDamage=2;

	// Outlets
	protected Rigidbody2D _ridgidbody2D;

	void Start() {
		_ridgidbody2D = GetComponent<Rigidbody2D>();
		_ridgidbody2D.velocity = transform.right * 8;
	}

	void OnCollisionEnter2D(Collision2D other) {
			var player = other.collider.GetComponent<PlayerController>();
			if(player){
					player.takeDamage(collisonDamage);
			}
		Destroy(gameObject);
	}
}
