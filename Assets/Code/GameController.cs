using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnEnemies : MonoBehaviour {

    public static SpawnEnemies instance;

    // Outlets
    public GameObject[] EnemyPrefabs;
    public GameObject[] BossPrefabs;

    // Configurations
    public int MAX_ENEMIES = 10;
    public int min_spawn_distance = 3;

    // State Tracking
    private int enemyCount;
    private int bossCount;
    private GameObject[] enemies;
    private GameObject[] bosses;
    Vector2 playerPos;
    private bool boss_was_spawned = false;
    private bool boss_is_alive = false;
    private int cur_stage = 1;
    private int new_enemy_stage = 3;
    private List<GameObject> availEnemyPrefabs = new List<GameObject>();

    // Time

    public TMP_Text timer;
    private float startTime;


    void Awake() {
        instance = this;
    }

    void Start() {
        startTime = Time.time;
        availEnemyPrefabs.Add(EnemyPrefabs[0]);
        availEnemyPrefabs.Add(EnemyPrefabs[1]);
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        bosses = GameObject.FindGameObjectsWithTag("Boss");
        enemyCount = enemies.Length;
        bossCount = bosses.Length;
        boss_is_alive = bossCount != 0;

        // keep track of stage
        if (Time.time > cur_stage*30f) {
          cur_stage += 1;
          MAX_ENEMIES = (int) ((float) MAX_ENEMIES * 1.25f);
          // new enemy type
          if (availEnemyPrefabs.Count < EnemyPrefabs.Length && cur_stage == new_enemy_stage) {
            availEnemyPrefabs.Add(EnemyPrefabs[availEnemyPrefabs.Count]);
            new_enemy_stage += 2;
          }
        }

        // reset for boss
        if (enemyCount != 0 &&boss_is_alive) {
          for (int i=0; i<enemyCount; i++) {
            Destroy(enemies[i]);
          }
        }

        // spawn random enemies
        if (enemyCount < MAX_ENEMIES && !boss_is_alive) {
            SpawnRandomEnemy();
        }

        // Spawn Boss 1
        if (Time.time > 30f && boss_was_spawned != true) {
            SpawnAnEnempy(BossPrefabs[0]);
            boss_was_spawned = true;
        }

        // Timer display
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timer.text = minutes + ":" + seconds;
    }

    void SpawnRandomEnemy() {

        // choose what enemy to spawn
        int enemyIndex = Random.Range(0, availEnemyPrefabs.Count);
        GameObject enemy_to_spawn = availEnemyPrefabs[enemyIndex];
        SpawnAnEnempy(enemy_to_spawn);
    }

    void SpawnAnEnempy(GameObject enemy_to_spawn) {
      playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
      int player_x = (int) playerPos.x;
      int player_y = (int) playerPos.y;
      // spawn close enough, but not too close to player
      Vector2 spawnPos;
      do {
        int xPos = Random.Range(player_x- 15, player_x+ 15);
        int yPos = Random.Range(player_y- 15, player_y+ 15);
        spawnPos = new Vector2(xPos, yPos);
      } while (Vector2.Distance(spawnPos, playerPos) < min_spawn_distance);

      Instantiate(enemy_to_spawn, spawnPos, Quaternion.identity);
    }

}
