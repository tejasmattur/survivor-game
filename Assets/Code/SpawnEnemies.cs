using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject Minotaur;
    public int xPos;
    public int yPos;
    public int enemyCount;

    void Start() {
        StartCoroutine(EnemySpawner());
    }

    void Update() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0) {
             Minotaur = enemies[0];
        }
        enemyCount = enemies.Length;
        // Debug.Log(enemies.Length);
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner() {
        while (enemyCount < 5) {
            xPos = Random.Range(-5, 5);
            yPos = Random.Range(-5, 5);
            Instantiate(Minotaur, new Vector2(xPos, yPos), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }

}
