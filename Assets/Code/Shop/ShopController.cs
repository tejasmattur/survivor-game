using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{

    public static ShopController instance;
    // Start is called before the first frame update
    public Canvas shopUI;
    public HUDController HUDController;

    public TMP_Text[] LevelTexts;
    public TMP_Text[] UpgradeTexts;

    private int spearIdx = 0;
    private int shurikenIdx = 1;
    private int bombIdx = 2;

    // State tracking
    private int[] Levels;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        shopUI.enabled = false;
        Levels = new int[] {1,0,0};
        UpgradeTexts[spearIdx].text = "+1 spear, increase firing rate";
        UpgradeTexts[shurikenIdx].text = "Unlock 5 randomly-shot shurikens";
        UpgradeTexts[bombIdx].text = "Unlock 3 bombs";
    }

    private void Update()
    {
        if (HUDController.curExp >= HUDController.maxExp)
        {
           openShop();
        }
    }

    public void openShop()
    {
        shopUI.enabled = true;
        Time.timeScale = 0f;

        for(int weaponIdx=0; weaponIdx < LevelTexts.Length; weaponIdx++) {
          if (Levels[weaponIdx] >= 5) {
            LevelTexts[weaponIdx].text = "Level 5";
          }
          else{
            LevelTexts[weaponIdx].text = string.Format("Level {0} --> {1}", Levels[weaponIdx], Levels[weaponIdx]+1);
          }
        }

    }

    public void closeShop()
    {
        shopUI.enabled = false;
        Time.timeScale = 1f;
    }

    public void upgradeSpear()
    {
      if (Levels[spearIdx] >= 5) {
        return;
      }
      Levels[spearIdx] += 1;
      switch(Levels[spearIdx]) {
        case 2:
          PlayerController.instance.maxSpears += 1;
          UpgradeTexts[spearIdx].text = "Decrease firing cooldown by 10%";  // for next level
          break;
        case 3:
          PlayerController.instance.cooldown *= 0.9f;
          UpgradeTexts[spearIdx].text = "Increase damage by 25%";  // for next level
          break;
        case 4:
          PlayerController.instance.spearDamageMultiplier = 1.25f;
          UpgradeTexts[spearIdx].text = "Greatly increase firing rate & speed"; // for next level
          break;
        case 5:
          PlayerController.instance.shotTime = 1.25f;
          UpgradeTexts[spearIdx].text = "Maximum level reached";
          break;
      }
      closeShop();
    }

    public void upgradeShuriken()
    {
      if (Levels[shurikenIdx] >= 5) {
        return;
      }
      Levels[shurikenIdx] += 1;
      switch(Levels[shurikenIdx]) {
        case 1:
          PlayerController.instance.shurikenDamageMultplier = 1f;
          UpgradeTexts[shurikenIdx].text = "+2 Shurikens";
          break;
        case 2:
          PlayerController.instance.maxShuriken += 2;
          UpgradeTexts[shurikenIdx].text = "Decrease firing cooldown by 20%";  // for next level
          break;
        case 3:
          PlayerController.instance.shurikenCooldown *= 0.8f;
          UpgradeTexts[shurikenIdx].text = "Increase damage by 30%";  // for next level
          break;
        case 4:
          PlayerController.instance.shurikenDamageMultplier = 1.3f;
          UpgradeTexts[shurikenIdx].text = "Greatly increase firing rate & speed"; // for next level
          break;
        case 5:
          PlayerController.instance.shurikenShotTime = 1.5f;
          UpgradeTexts[shurikenIdx].text = "Maximum level reached";
          break;
      }
      closeShop();
    }

    public void upgradeBomb() {
      if (Levels[bombIdx] >= 5) {
        return;
      }
      Levels[bombIdx] += 1;
      switch(Levels[bombIdx]) {
        case 1:
          PlayerController.instance.bombDamageMultiplier = 1f;
          UpgradeTexts[bombIdx].text = "+1 Bomb";
          break;
        case 2:
          PlayerController.instance.maxBombs += 1;
          UpgradeTexts[bombIdx].text = "Increase damage by 25%";  // for next level
          break;
        case 3:
          PlayerController.instance.bombDamageMultiplier = 1.25f;
          UpgradeTexts[bombIdx].text = "+2 Bombs";  // for next level
          break;
        case 4:
          PlayerController.instance.maxBombs += 2;
          UpgradeTexts[bombIdx].text = "Greatly increase bomb cooldown"; // for next level
          break;
        case 5:
          PlayerController.instance.bombCooldown = 0.5f;
          UpgradeTexts[bombIdx].text = "Maximum level reached";
          break;
      }
      closeShop();
    }

    public void upgradeMaxHealth()
    {
      PlayerController.instance.maxHealth += 1;
      closeShop();
    }

}
