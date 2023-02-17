using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : BaseEnemy
{

    void Start() {
      setBasicConfigurations();
    }

    void Update() {
      moveTowardPlayer();
    }

}
