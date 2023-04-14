using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUpgrade
{
  public int cur_level;
  public string[] upgrade_texts;
  public string item_name;

  public abstract void upgrade();

  public int getCurLevel() {
    return cur_level;
  }
  public string getUpgradeText() {
    return upgrade_texts[cur_level];
  }

  public string getItemName() {
    return item_name;
  }
}
