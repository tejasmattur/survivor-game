using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Outlet
	Rigidbody2D _rigidbody2D;
	protected float HitPoints;
	public float maxHealth = 10;
    public float speed;
    SpriteRenderer sprite;
    Animator animator;
    public GameOver gameOver;
    // Weapons
    public GameObject spearPrefab;

    // Weapons Effect
    public int maxSpears = 3;
    public int spearsLeft = 3;
    public float cooldown = 1.0f;
    public float shotTime = 2.0f;
    private float nextFire = 0.0f;
    public int coinCount = 0;

    // HUD
		public HealthBar healthBar;



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
		HitPoints = maxHealth;
	    healthBar.setHealth(HitPoints, maxHealth);
     
    }

    void FixedUpdate() {
    	// This Update Event is sync'd with the Physics Engine
    	animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);
    	if (_rigidbody2D.velocity.magnitude > 0) {
    		animator.speed = _rigidbody2D.velocity.magnitude / 3f;
    	}
    	else {
    		animator.speed = 1f;
    	}
    }

    // Update is called once per frame
    void Update()
    {

    	// Move left
    	if(Input.GetKey(KeyCode.A)) {
    		_rigidbody2D.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
    		sprite.flipX = true;
    	}

    	// Move right
    	if(Input.GetKey(KeyCode.D)) {
    		_rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
    		sprite.flipX = false;
    	}

    	// Move Uo
    	if(Input.GetKey(KeyCode.W)) {
    		_rigidbody2D.AddForce(Vector2.up * speed * Time.deltaTime, ForceMode2D.Impulse);
    	}

    	// Move Down
    	if(Input.GetKey(KeyCode.S)) {
    		_rigidbody2D.AddForce(Vector2.down * speed * Time.deltaTime, ForceMode2D.Impulse);
    	}

    	// Check for enemies
    	GameObject[] minotaurs = GameObject.FindGameObjectsWithTag("Minotaur");
        GameObject[] golems = GameObject.FindGameObjectsWithTag("Golem");

        GameObject[] enemies = minotaurs.Concat(golems).ToArray();

        Vector2 cur_pos = transform.position;

			// update attack animation
    	if (!animator.GetBool("Attack") && animator.GetFloat("Speed") < 0.1 && enemies.Length != 0) {
    		animator.SetBool("Attack", true);
    	}
    	else if (animator.GetFloat("Speed") > 0.1) {
    		animator.SetBool("Attack", false);
    	}

			// attack closest enemy first
			enemies = enemies.OrderBy((e) => (e.transform.position - transform.position).sqrMagnitude).ToArray();
    	for (int i=0; i < enemies.Length; i++) {
    		Vector2 e_pos = enemies[i].transform.position;
    		Vector2 enemy_dir = e_pos - cur_pos;
    		float fireAngle = getBetweenAngle(Vector2.right, enemy_dir);
    		enemy_dir.Normalize();

    		// Fire
    		if (Time.time > nextFire) {

    			GameObject newSpear = Instantiate(spearPrefab);
    			newSpear.transform.position = cur_pos + enemy_dir;
    			newSpear.transform.rotation = Quaternion.Euler(0.0f, 0.0f, fireAngle);
    			spearsLeft -= 1;

    			if (spearsLeft == 0) { // Cool down
	    			spearsLeft = maxSpears;
	    			nextFire = Time.time + cooldown;
	    		}
	    		else {
	    			nextFire = Time.time + shotTime/maxSpears;
	    		}
    		}

    	}
    }

		// collide with enemies
	  void OnCollisionEnter2D(Collision2D other) {
        var enemy = other.collider.GetComponent<BaseEnemy>();
        if(enemy){
			HitPoints -= enemy.collisonDamage;
			healthBar.setHealth(HitPoints, maxHealth);
			// Restart Level when player health is 0
			if(HitPoints == 0){
                gameOver.gameOver();
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
        }
    }

 	 private float getBetweenAngle(Vector2 v1, Vector2 v2) {
 	 	 Vector2 v1_r90 = new Vector2(-v1.y, v1.x);
	     float sign = (Vector2.Dot(v1_r90, v2) < 0) ? -1.0f : 1.0f;
	     return Vector2.Angle(v1, v2) * sign;
	 }

}
