using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;

    public float weaponDamage = 3f;
    public float explosionDelay = 0.5f;
    public float explosionRadius = 1.5f;

    private float explosionStart = -1f;

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
        Debug.Log(directionToEnemy.sqrMagnitude);
        if(directionToEnemy.sqrMagnitude < explosionRadius) {
            enemies[i].takeDamage(weaponDamage);
            Debug.Log("An enemy got damaged");
        }
      }

    }

    void OnCollisionEnter2D(Collision2D other) {
        var enemy = other.collider.GetComponent<BaseEnemy>();
        if(enemy && explosionStart==-1){ // not yet triggered
            explosionStart = Time.time;
        }
    }


}
