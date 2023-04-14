using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenUpgrade : BaseUpgrade
{
    public ShurikenUpgrade() {
      cur_level = 0;
      item_name = "Sharpy Shuriken";
      upgrade_texts =  new string[] {
        "Unlock 5 randomly-shot shurikens",
        "+2 Shurikens",
        "Decrease firing cooldown by 20%",
        "Increase damage by 30%",
        "Greatly increase firing rate & speed",
        "Maximum level reached"
      };
    }

    public override void upgrade() {
      cur_level += 1;
      switch(cur_level) {
        case 1:
          PlayerController.instance.shurikenDamageMultplier = 1f;
          break;
        case 2:
          PlayerController.instance.maxShuriken += 2;
          break;
        case 3:
          PlayerController.instance.shurikenCooldown *= 0.8f;
          break;
        case 4:
          PlayerController.instance.shurikenDamageMultplier *= 1.3f;
          break;
        case 5:
          PlayerController.instance.shurikenShotTime = 1.5f;
          break;
        }
    }

}
