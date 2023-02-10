using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float HitPoints;
    public float maxHealth = 10;
    public HealthBar healthBar;
    public SpawnEnemies spawner;

    void Start()
    {
        HitPoints = maxHealth;
        healthBar.setHealth(HitPoints, maxHealth);
        
    }

    // Update is called once per frame
    public void takeDamage(float damage)
    {

        HitPoints -= damage;
        healthBar.setHealth(HitPoints, maxHealth);
        if(HitPoints == 0){
            Destroy(gameObject);
            spawner.enemyCount -= 1;
        }
        
    }
}
