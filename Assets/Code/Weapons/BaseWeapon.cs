using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{

  	// Outlets
  	protected Rigidbody2D _ridgidbody2D;
    public float weaponDamage;

    protected void setBasicConfigurations() {
      _ridgidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        var enemy = other.collider.GetComponent<BaseEnemy>();
        if(enemy){
            enemy.takeDamage(weaponDamage);
        }
    	Destroy(gameObject);
    }
}
