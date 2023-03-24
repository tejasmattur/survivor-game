using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeBase : MonoBehaviour
{
    public int price;
    protected PlayerController playerController;

    private void Start()
    {
        playerController = PlayerController.instance;
    }

    public virtual void PurchaseUpgrade()
    {
        if (playerController.coinCount >= price)
        {
            // Deduct the price from the player's total coin count.
            playerController.coinCount -= price;
            ApplyUpgrade();
        }
        else
        {
            Debug.Log("Not enough coins to buy upgrade!");
        }
    }

    protected abstract void ApplyUpgrade();
}
