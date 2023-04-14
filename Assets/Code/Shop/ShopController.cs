using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    public static ShopController instance;

    public Canvas shopUI;
    public HUDController HUDController;

    public TMP_Text[] ItemNameTexts;
    public TMP_Text[] LevelTexts;
    public TMP_Text[] UpgradeTexts;

    private BaseUpgrade[] upgrades;
    private int[] chosen_upgrades;

    public Image[] ImageHolders;
    public Sprite[] ItemSprites;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        shopUI.enabled = false;
        upgrades = new BaseUpgrade[] {
          new SpearUpgrade(), new BombUpgrade(), new ShurikenUpgrade(),
          new BallUpgrade(), new HealthUpgrade()
        };
    }

    private void Update()
    {
        if (HUDController.curExp >= HUDController.maxExp)
        {
           openShop();
        }
    }

    private int[] randomNoReplacement(int n, int size) {
      int[] chosen_idxes = new int[] {99, 99, 99};
      int idx = 0;
      int new_idx = UnityEngine.Random.Range(0, n);
      while (idx < chosen_idxes.Length) {
        while(Array.IndexOf(chosen_idxes, new_idx) > -1) {
          new_idx = UnityEngine.Random.Range(0, n);
        }
        chosen_idxes[idx] = new_idx;
        idx += 1;
      }
      return chosen_idxes;
    }

    public void openShop()
    {
        shopUI.enabled = true;
        Time.timeScale = 0f;

        chosen_upgrades = randomNoReplacement(upgrades.Length, 3);

        for(int i=0; i < 3; i++) {
          int item_idx = chosen_upgrades[i];
          int cur_level = upgrades[item_idx].getCurLevel();
          if (cur_level >= 5) {
            LevelTexts[i].text = "Level 5";
          }
          else{
            LevelTexts[i].text = string.Format("Level {0} --> {1}", cur_level, cur_level+1);
          }
          UpgradeTexts[i].text = upgrades[item_idx].getUpgradeText();
          ItemNameTexts[i].text = upgrades[item_idx].getItemName();
          ImageHolders[i].sprite = ItemSprites[item_idx];
        }

        Debug.Log("Chosen upgrades: " + chosen_upgrades[0].ToString() + ", " + chosen_upgrades[1].ToString() + ", " + chosen_upgrades[2].ToString());
    }

    public void upgradeItem(int idx) {
      int upgrade_idx = chosen_upgrades[idx];
      Debug.Log("Upgrading item at index" + upgrade_idx.ToString());
      upgrades[upgrade_idx].upgrade();
      closeShop();
    }

    public void closeShop()
    {
        shopUI.enabled = false;
        Time.timeScale = 1f;
    }

}
