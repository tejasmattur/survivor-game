using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapColliders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }

        //if (other.CompareTag("Player"))
        //{
        //    isCollidingPlayer = true;
        //}

        //if (other.CompareTag("Enemy"))
        //{ 
        //    isCollidingEnemy = true;
        //}


    }
}
