using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public static SpawnEnemies instance;

    // Outlets
    public GameObject[] EnemyPrefabs;

    // Configurations
    public int MAX_ENEMIES = 10;
    public int min_spawn_distance = 2;

    // State Tracking
    private int enemyCount;
    private GameObject[] enemies;
    Vector2 playerPos;

    void Awake() {
        instance = this;
    }

    void Start() {

    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;

        if (enemyCount < MAX_ENEMIES) {
            SpawnRandomEnemy();
        }
    }

    void SpawnRandomEnemy() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        int player_x = (int) playerPos.x;
        int player_y = (int) playerPos.y;
        // spawn close enough, but not too close to player
        Vector2 spawnPos;
        do {
          int xPos = Random.Range(player_x- 10, player_x+ 10);
          int yPos = Random.Range(player_y- 10, player_y+ 10);
          spawnPos = new Vector2(xPos, yPos);
        } while (Vector2.Distance(spawnPos, playerPos) < min_spawn_distance);

        // choose what enemy to spawn
        float probability = Random.Range(0,100);
        Debug.Log(probability);
        GameObject enemy_to_spawn;
        if (probability < 70) { // golems get spawned more often
          enemy_to_spawn = EnemyPrefabs[0];
        }
        else {
          enemy_to_spawn = EnemyPrefabs[1];
        }
        Instantiate(enemy_to_spawn, spawnPos, Quaternion.identity);
    }

}