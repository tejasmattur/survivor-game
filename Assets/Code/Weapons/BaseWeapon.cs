using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{

  	// Outlets
  	protected Rigidbody2D _ridgidbody2D;
    public float weaponDamage;
    public int weaponLevel;

    public BaseWeapon(float damage, int level)
    {
        weaponDamage = damage;
        weaponLevel = level;
    }

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

    public void IncreaseDamage(float amount)
    {
        weaponDamage += amount;
    }

    public void IncreaseLevel(int amount)
    {
        weaponLevel += amount;
    }

}
