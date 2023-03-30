using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWraith : BaseEnemy
{
    public GameObject energyPrefab;
    public int max_dashes = 3;
    public int dashes_left = 3;
    public float dash_delay = 0.5f;
    public float dash_duration = 1f;
    public float cooldown = 3f;
    private float nextDash = 0f;
    private Vector2 dir_to_player;
    private bool dir_was_set = false;

    void Start() {
      setBasicConfigurations();
    }

    void Update() {
        if (Time.time > nextDash) {
          if (!dir_was_set) {
            setDirToPlayer();
            dir_was_set = true;
            nextDash = Time.time + dash_delay;
            return;
          }
          else {
            dashTowardPlayer(dir_to_player, 50f);
            dashes_left -= 1;
            dir_was_set = false;
            if (dashes_left == 0) {
              dashes_left = max_dashes;
              nextDash = Time.time + cooldown;
            }
            else {
              nextDash = Time.time + dash_delay;
            }
          }

        }

        else {
          moveTowardPlayer();
        }
    }


    void dashTowardPlayer(Vector2 dir_to_player, float dash_speed) {
      Debug.Log("Dashed!");
      _rigidbody2D.AddForce(dir_to_player * dash_speed, ForceMode2D.Impulse);
    }

    void setDirToPlayer() {
      Vector2 cur_pos = transform.position;
      Vector2 player_pos = player.transform.position;
      dir_to_player = player_pos - cur_pos;
      dir_to_player.Normalize();
    }

}
