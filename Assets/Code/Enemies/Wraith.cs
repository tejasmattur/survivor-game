using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : BaseEnemy
{
  // Outlets
  public GameObject spellPrefab;

  // State tracking
  public float cooldown = 3f;
  private float nextFire = 3f;

    void Start() {
      setBasicConfigurations();
    }

    void Update() {
      if (Time.time > nextFire) {
        Vector2 player_pos = player.transform.position;
        Vector2 cur_pos = transform.position;
    		Vector2 dir_to_player = player_pos - cur_pos;
        dir_to_player.Normalize();

    		float fireAngle = getBetweenAngle(Vector2.right, dir_to_player);

        GameObject newClub = Instantiate(spellPrefab);
        newClub.transform.position = cur_pos + dir_to_player;
        newClub.transform.rotation = Quaternion.Euler(0.0f, 0.0f, fireAngle);

  			nextFire = Time.time + cooldown;
      }
      else {
          moveTowardPlayer();
      }
    }

}
