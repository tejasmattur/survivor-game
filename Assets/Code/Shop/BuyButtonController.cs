using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonController : MonoBehaviour
{
    enum PurchaseType
    {
        HealthUpgrade,
        WeaponUpgrade,
        WeaponPurchase
    }

    public int purchaseType;
    public int price;

    // Start is called before the first frame update
    public void onClick()
    {
        switch (purchaseType)
        {
            case (int)PurchaseType.HealthUpgrade:
                HealthUpgrade healthUpgrade = new HealthUpgrade();
                ShopController.instance.buyUpgrade(price, healthUpgrade);
                break;

            case (int)PurchaseType.WeaponUpgrade:
                WeaponUpgrade weaponUpgrade = new WeaponUpgrade();
                ShopController.instance.buyUpgrade(price, weaponUpgrade);
                break;

            case (int)PurchaseType.WeaponPurchase:
                WeaponPurchase weaponPurchase = new WeaponPurchase();
                ShopController.instance.buyUpgrade(price, weaponPurchase);
                break;

            default:
                break;
        }
    }
}
