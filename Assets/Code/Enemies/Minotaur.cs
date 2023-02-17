using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : BaseEnemy
{

    void Start() {
      setBasicConfigurations();
    }

    void Update() {
      moveTowardPlayer();
    }

}
