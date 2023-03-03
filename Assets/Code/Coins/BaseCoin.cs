using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCoin : MonoBehaviour
{

    protected GameObject player;

    protected int coinValue = 1;
    protected float dropProbability = 1;
    public int totalCoinCount = 0;
    //// Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Increment total value and destroy the coin
            //CoinManager.instance.AddCoins(coinValue);
            //playerController.coinCount += coinValue;
            player.GetComponent<PlayerController>().coinCount += coinValue;
            totalCoinCount = player.GetComponent<PlayerController>().coinCount;
            Debug.Log("Total Coin: " + totalCoinCount);
            UpdateCoinText();
            Destroy(gameObject);
        }
    }

    void UpdateCoinText()
    {
        player.GetComponent<PlayerController>().coinText.text = "Coins: " + player.GetComponent<PlayerController>().coinCount.ToString();
       
    }


}
