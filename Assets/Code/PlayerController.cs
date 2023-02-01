using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Outlet
	Rigidbody2D _rigidbody2D;
	// public GameObject projectilePrefab;

	// Configuration
    public float speed;	

	// Methods
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    	// Move left
    	if(Input.GetKey(KeyCode.A)) {
    		_rigidbody2D.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
    	}

    	// Move right
    	if(Input.GetKey(KeyCode.D)) {
    		_rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
    	}

    	// Move Uo
    	if(Input.GetKey(KeyCode.W)) {
    		_rigidbody2D.AddForce(Vector2.up * speed * Time.deltaTime, ForceMode2D.Impulse);
    	}

    	// Move Down
    	if(Input.GetKey(KeyCode.S)) {
    		_rigidbody2D.AddForce(Vector2.down * speed * Time.deltaTime, ForceMode2D.Impulse);
    	}

    }

}
