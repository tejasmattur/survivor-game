using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float HitPoints;
    public float maxHealth = 10;
    public float speed;
    protected Rigidbody2D _rigidbody2D;
    protected GameObject player;
    public HealthBar healthBar;
    public SpawnEnemies spawner;

    // Update is called once per frame
    public void takeDamage(float damage)
    {
        HitPoints -= damage;
        healthBar.setHealth(HitPoints, maxHealth);
        if(HitPoints <= 0){
            Destroy(gameObject);
            spawner.enemyCount -= 1;
        }
    }

}
