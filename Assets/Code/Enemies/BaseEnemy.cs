using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CoinType {
    health,
    def,
    red
}

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    protected float HitPoints;
    public float maxHealth = 10;
    public float speed;
    public float collisonDamage = 1;
    protected Rigidbody2D _rigidbody2D;
    SpriteRenderer sprite;
    protected GameObject player;
    public HealthBar healthBar;
    public GameObject coin;
    public GameObject[] coinObjects;
    public float[] coinDropProbabilities;

    void onDeath()
    {
        GameObject coinToDrop;
        float randomValue = Random.value;
        if (randomValue <= coinDropProbabilities[(int)CoinType.health])
        {
            coinToDrop = coinObjects[(int)CoinType.health];
            // console.log("health spawn");
        }
        else if (randomValue <= coinDropProbabilities[(int)CoinType.def]) {
            coinToDrop = coinObjects[(int)CoinType.def];
        }
        else
        {
            coinToDrop = coinObjects[(int)CoinType.red];
        }

        Vector3 position = transform.position;
        position = new Vector3(position.x, position.y, -1);
        Instantiate(coinToDrop, position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected void setBasicConfigurations() {
      HitPoints = maxHealth;
      healthBar.setHealth(HitPoints, maxHealth);
      _rigidbody2D = GetComponent<Rigidbody2D>();
      sprite = GetComponent<SpriteRenderer>();
      player = GameObject.FindGameObjectWithTag("Player");
    }

    public void takeDamage(float damage)
    {
        HitPoints -= damage;
        healthBar.setHealth(HitPoints, maxHealth);
        if(HitPoints <= 0){
            //Instantiate(coin, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            SoundManager.instance.PlaySound("death");
            onDeath();
        }
    }

    protected void moveTowardPlayer() {
      Vector2 cur_pos = transform.position;
      Vector2 player_pos = player.transform.position;
      Vector2 dir_to_player = player_pos - cur_pos;
      dir_to_player.Normalize();
      _rigidbody2D.AddForce(dir_to_player * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    protected void moveTowardPlayer(float input_speed) {
      Vector2 cur_pos = transform.position;
      Vector2 player_pos = player.transform.position;
      Vector2 dir_to_player = player_pos - cur_pos;
      dir_to_player.Normalize();
      _rigidbody2D.AddForce(dir_to_player * input_speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    protected float getBetweenAngle(Vector2 v1, Vector2 v2) {
  	 	 Vector2 v1_r90 = new Vector2(-v1.y, v1.x);
 	     float sign = (Vector2.Dot(v1_r90, v2) < 0) ? -1.0f : 1.0f;
 	     return Vector2.Angle(v1, v2) * sign;
 	 }

}
