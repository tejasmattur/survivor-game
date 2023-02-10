using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{

	// Outlets
	Rigidbody2D _ridgidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _ridgidbody2D = GetComponent<Rigidbody2D>();
        _ridgidbody2D.velocity = transform.right * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {

        var enemy = other.collider.GetComponent<Enemy>();
        if(enemy){
            enemy.takeDamage(1);
        }
    	Destroy(gameObject);
    }
}
