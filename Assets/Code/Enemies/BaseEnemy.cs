using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    protected float HitPoints;
    public float maxHealth = 10;
    public float speed;
    public float collisonDamage = 1;
    protected Rigidbody2D _rigidbody2D;
    protected GameObject player;
    public HealthBar healthBar;
    public SpawnEnemies spawner;
    public GameObject coin;

    protected void setBasicConfigurations() {
      HitPoints = maxHealth;
      healthBar.setHealth(HitPoints, maxHealth);
      _rigidbody2D = GetComponent<Rigidbody2D>();
      player = GameObject.FindGameObjectWithTag("Player");
    }

    public void takeDamage(float damage)
    {
        HitPoints -= damage;
        healthBar.setHealth(HitPoints, maxHealth);
        if(HitPoints <= 0){
            //if(gameObject.tag == "Golem")
            //{
            //    spawner.Golem = GameObject.FindGameObjectWithTag("Golem");
            //}
            //if(gameObject.tag == "Minotaur")
            //{
            //    spawner.Minotaur = GameObject.FindGameObjectWithTag("Minotaur");
            //}
            //spawner.enemyCount--;
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    protected void moveTowardPlayer() {
      Vector2 cur_pos = transform.position;
      Vector2 player_pos = player.transform.position;
      Vector2 dir_to_player = player_pos - cur_pos;
      dir_to_player.Normalize();
      _rigidbody2D.AddForce(dir_to_player * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

}
