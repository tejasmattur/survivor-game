using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : BaseUpgrade
{
    public HealthUpgrade() {
      cur_level = 0;
      item_name = "Hearty Health";
      upgrade_texts =  new string[] {
        "Increase max health by 20%",
        "Increase max health by 40%",
        "Increase max health by 60%",
        "Increase max health by 80%",
        "Increase max health by 100%",
        "Maximum level reached"
      };
    }


    public override void upgrade() {
      cur_level += 1;
      PlayerController.instance.maxHealth += 2;
      if (PlayerController.instance.HitPoints + 2 > PlayerController.instance.maxHealth) {
        PlayerController.instance.HitPoints = PlayerController.instance.maxHealth;
      }
      else {
        PlayerController.instance.HitPoints += 2;
      }
      PlayerController.instance.healthBar.setHealth(PlayerController.instance.HitPoints, PlayerController.instance.maxHealth);
    }
}
