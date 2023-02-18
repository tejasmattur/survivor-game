using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject Minotaur;
    public GameObject Golem;
    public int xPos;
    public int yPos;
    public int enemyCount = 0;
    private GameObject[] gameObjects;

    void Start() {
        StartCoroutine(EnemySpawner());
    }


    void Update()
    {
        GameObject[] minotaurs = GameObject.FindGameObjectsWithTag("Minotaur");
        GameObject[] golems = GameObject.FindGameObjectsWithTag("Golem");
        if (minotaurs.Length > 0)
        {
            Minotaur = minotaurs[0];
        }

        if (golems.Length > 0)
        {
            Golem = golems[0];
        }
        enemyCount = minotaurs.Length + golems.Length;
        Debug.Log(minotaurs.Length);
        Debug.Log(golems.Length);
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {

        while (enemyCount < 5)
        {
            double probability = Random.Range(0, 1);
            xPos = Random.Range(-15, 15);
            yPos = Random.Range(-15, 15);
            if (probability < 0.7)
            {
                Instantiate(Minotaur, new Vector2(xPos, yPos), Quaternion.identity);
            }
            else
            {
                Instantiate(Golem, new Vector2(xPos, yPos), Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }

}
