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
    }

    void Update() {
      if (Time.time > nextFire) {
        Vector2 player_pos = player.transform.position;
        Vector2 cur_pos = transform.position;
    		Vector2 dir_to_player = player_pos - cur_pos;
        dir_to_player.Normalize();

    		float fireAngle = getBetweenAngle(Vector2.right, dir_to_player);
        float[] fireAngles = new float[] {fireAngle-20, fireAngle, fireAngle+20};

        for (int i=0; i< fireAngles.Length; i++) {
          GameObject newClub = Instantiate(clubPrefab);
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

    private float getBetweenAngle(Vector2 v1, Vector2 v2) {
  	 	 Vector2 v1_r90 = new Vector2(-v1.y, v1.x);
 	     float sign = (Vector2.Dot(v1_r90, v2) < 0) ? -1.0f : 1.0f;
 	     return Vector2.Angle(v1, v2) * sign;
 	 }

}
