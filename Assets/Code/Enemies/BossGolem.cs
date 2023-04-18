using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGolem : BaseEnemy
{
    // Outlets
    public GameObject clubPrefab;

    // State tracking
    public int maxClubs = 2;
    public int clubsLeft = 2;
    public float cooldown = 10.0f;
    public float shotTime = 2.0f;
    private float nextFire = 3f;


    void Start() {
      setBasicConfigurations();
        SoundManager.instance.PlaySound("golem spawn");
    }

    void Update() {
      if (Time.time > nextFire) {
        Vector2 player_pos = player.transform.position;
        Vector2 cur_pos = transform.position;
    		Vector2 dir_to_player = player_pos - cur_pos;
        dir_to_player.Normalize();

    		float fireAngle = getBetweenAngle(Vector2.right, dir_to_player);
        float[] fireAngles = new float[] {fireAngle-25, fireAngle, fireAngle+25};

        for (int i=0; i< fireAngles.Length; i++) {
          GameObject newClub = Instantiate(clubPrefab);
          SoundManager.instance.PlaySound("golem shoot");
          newClub.transform.position = cur_pos + dir_to_player;
          newClub.transform.rotation = Quaternion.Euler(0.0f, 0.0f, fireAngles[i]);
        }
        clubsLeft -= 1;

  			if (clubsLeft == 0) { // Cool down
    			clubsLeft = maxClubs;
    			nextFire = Time.time + cooldown;
    		}
    		else {
    			nextFire = Time.time + shotTime/maxClubs;
    		}
      }
      else {
          moveTowardPlayer();
      }
    }


}
