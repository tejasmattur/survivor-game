using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyWeapon : MonoBehaviour
{

  	// Outlets
  	protected Rigidbody2D _ridgidbody2D;
    public float weaponDamage;

    protected void setBasicConfigurations() {
      _ridgidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
  			var player = other.collider.GetComponent<PlayerController>();
  			if(player){
  					player.takeDamage(weaponDamage);
  			}
  		Destroy(gameObject);
    }
}
