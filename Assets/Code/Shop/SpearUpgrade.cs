using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearUpgrade : BaseUpgrade
{
  public SpearUpgrade() {
    cur_level = 1;
    item_name = "Pointy Spear";
    upgrade_texts =  new string[] {
      "N/A",
      "+1 spear, increase firing rate",
      "Decrease firing cooldown by 10%",
      "Increase damage by 25%",
      "Greatly increase firing rate & speed",
      "Maximum level reached"
    };
  }

    public override void upgrade() {
      cur_level += 1;
      switch(cur_level) {
        case 2:
          PlayerController.instance.maxSpears += 1;
          break;
        case 3:
          PlayerController.instance.cooldown *= 0.9f;
          break;
        case 4:
          PlayerController.instance.spearDamageMultiplier *= 1.25f;
          break;
        case 5:
          PlayerController.instance.shotTime = 1.25f;
          break;
        }
    }


}
