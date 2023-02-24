using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : BaseCoin
{
    void Start()
    {
        coinValue = 5;
        dropProbability = 0.7f;
    }
}
