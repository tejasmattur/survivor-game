using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCoin : MonoBehaviour
{
    public static BaseCoin instance;
    protected GameObject player;
    SpriteRenderer sprite;

    public int coinValue = 1;
    //public float dropProbability = 1f;
    public int totalCoinCount = 0;

    private void Awake()
    {
        instance = this;
    }

    //// Start is called before the first frame update
    protected void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().coinCount += coinValue;
            totalCoinCount = player.GetComponent<PlayerController>().coinCount;
            HUDController.instance.curExp += coinValue;
            UpdateCoinText();
            Destroy(gameObject);
        }
    }

    public void UpdateCoinText()
    {
        player.GetComponent<PlayerController>().coinText.text = player.GetComponent<PlayerController>().coinCount.ToString();
       
    }

    //protected void setBasicConfigurations()
    //{
    //    sprite = GetComponent<SpriteRenderer>();
    //    player = GameObject.FindGameObjectWithTag("Player");
    //}

}
