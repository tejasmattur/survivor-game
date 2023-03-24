using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    public static ShopController instance;
    // Start is called before the first frame update
    public Canvas shopUI;
    public HUDController HUDController;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        shopUI.enabled = false;
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
    }

    public void closeShop()
    {
        shopUI.enabled = false;
        Time.timeScale = 1f;
    }

    public void markPurchaseType() 
    {
        HealthUpgrade healthUpgrade = new HealthUpgrade();
        buyUpgrade(10, healthUpgrade);
    }

    public void buyUpgrade(int thisPrice, UpgradeBase upgrade)
    {
        upgrade.price = thisPrice;
        upgrade.PurchaseUpgrade();
    }

}
