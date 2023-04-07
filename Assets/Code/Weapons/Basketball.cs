using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : BaseWeapon
{

    public int MaxBounces = 3;
    private int bounce = 0; // for weapons that ricochet

    void Start()
    {
      setBasicConfigurations();
      _ridgidbody2D.velocity = transform.right * 15 * weaponSpeedMultiplier;
    }

    void OnCollisionEnter2D(Collision2D other) {
        var enemy = other.collider.GetComponent<BaseEnemy>();
        if(enemy){
            enemy.takeDamage(weaponDamage*weaponDamageMultiplier);
        }
        // ricochet
        Vector2 normal = other.contacts[0].normal;
        Vector2 ricochet_dir = Vector2.Reflect(_ridgidbody2D.velocity, normal);
        ricochet_dir.Normalize();
        _ridgidbody2D.velocity = ricochet_dir * 15 * weaponSpeedMultiplier;

        bounce += 1;
        if (bounce > MaxBounces) {
          Destroy(gameObject);
        }
    }


}
