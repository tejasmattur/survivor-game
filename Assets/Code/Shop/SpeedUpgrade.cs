using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : MonoBehaviour
{
    private int cur_level = 0;
    private string[] upgrade_texts =  new string[] {
      "Increase speed by 10%",
      "+2 balls",
      "Increase damage by 10%",
      "Decrease cooldown and shot time",
      "+2 balls",
      "Maximum level reached"
    };

    public void upgrade() {
      cur_level += 1;
      switch(cur_level) {
        case 1:
          PlayerController.instance.ballDamageMultiplier = 1f;
          break;
        case 2:
          PlayerController.instance.maxBalls += 2;
          break;
        case 3:
          PlayerController.instance.ballDamageMultiplier *= 1.1f;
          break;
        case 4:
          PlayerController.instance.ballCooldown *= 0.8f;
          PlayerController.instance.ballShotTime *= 0.8f;
          break;
        case 5:
          PlayerController.instance.maxBalls += 2;
          break;
        }
    }
}
