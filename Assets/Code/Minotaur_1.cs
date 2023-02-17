using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_1 : BaseEnemy
{
    // Start is called before the first frame update

    void Start() {
      HitPoints = maxHealth;
      healthBar.setHealth(HitPoints, maxHealth);
      _rigidbody2D = GetComponent<Rigidbody2D>();
      player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
      Vector2 cur_pos = transform.position;
      Vector2 player_pos = player.transform.position;
      Vector2 dir_to_player = player_pos - cur_pos;
      dir_to_player.Normalize();
      _rigidbody2D.AddForce(dir_to_player * speed * Time.deltaTime, ForceMode2D.Impulse);
      Debug.Log(dir_to_player);
    }

}
