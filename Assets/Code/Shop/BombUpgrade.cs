using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUpgrade : BaseUpgrade
{
  public BombUpgrade() {
    cur_level = 0;
    item_name = "Spiky Bomb";
    upgrade_texts =  new string[] {
      "Unlock 2 bombs",
      "+1 Bomb",
      "Increase damage by 25%",
      "+2 Bombs",
      "Greatly decrease bomb cooldown",
      "Maximum level reached"
    };
  }


    public override void upgrade() {
      cur_level += 1;
      Debug.Log("Upgade bomb to level " + cur_level.ToString());
      switch(cur_level) {
        case 1:
          PlayerController.instance.bombDamageMultiplier = 1f;
          break;
        case 2:
          PlayerController.instance.maxBombs += 1;
          break;
        case 3:
          PlayerController.instance.bombDamageMultiplier *= 1.25f;
          break;
        case 4:
          PlayerController.instance.maxBombs += 2;
          break;
        case 5:
          PlayerController.instance.bombCooldown = 0.5f;
          break;
        }
    }


}
