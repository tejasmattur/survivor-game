using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;

    public float weaponDamage = 3f;
    public float explosionDelay = 0.5f;
    public float explosionRadius = 10f;
    private float explosionStart = -1f;

    public float weaponDamageMultiplier = 1f;

    private BaseEnemy[] enemies;

    void Start()
    {

    }

    void Update()
    {
        if (explosionStart != -1 && Time.time > explosionStart + explosionDelay) {
          Explode();
        }
    }

    void Explode() {

      Destroy(gameObject);

        SoundManager.instance.PlaySound("explode");
      // explosion animation
      GameObject explosion = Instantiate(
        explosionPrefab,
        transform.position,
        Quaternion.identity
      );
      Destroy(explosion, 0.5f);

      // damage enemies within radius
      enemies = FindObjectsOfType<BaseEnemy>();
      for(int i=0; i< enemies.Length; i++) {
        Vector2 directionToEnemy = enemies[i].transform.position - transform.position;
        if(directionToEnemy.sqrMagnitude < explosionRadius) {
            enemies[i].takeDamage(weaponDamage*weaponDamageMultiplier);
            Debug.Log("An enemy got damaged");
        }
      }

    }

    void OnTriggerEnter2D(Collider2D other) {
        var enemy = other.GetComponent<BaseEnemy>();
        if(enemy && explosionStart==-1){ // not yet triggered
            explosionStart = Time.time;
        }
    }


}
