using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : BaseCoin
{
    void Start()
    {
        base.Start();
        coinValue = 5;
        //dropProbability = 0.4f;
    }
}
