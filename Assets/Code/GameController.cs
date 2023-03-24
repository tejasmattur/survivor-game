using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {

    public static GameController instance;

    // Outlets
    public GameObject[] EnemyPrefabs;
    public GameObject[] BossPrefabs;
    public Image bossHealthImage;
    public int level;

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

    // constants
    private int MAX_X = 15;
    private int MIN_X = -110;
    private int MAX_Y = 17;
    private int MIN_Y = -45;

    // Time

    public TMP_Text timer;
    private float startTime;

    public string timerText;

    void Awake() {
        instance = this;
    }

    public void Reset() {
      startTime = Time.time;
      level = 1;

      availEnemyPrefabs = new List<GameObject>();
      availEnemyPrefabs.Add(EnemyPrefabs[0]);
      availEnemyPrefabs.Add(EnemyPrefabs[1]);

      // reset enemies and bosse
      enemies = GameObject.FindGameObjectsWithTag("Enemy");
      bosses = GameObject.FindGameObjectsWithTag("Boss");
      for (int i=0; i<enemies.Length; i++) {
        Destroy(enemies[i]);
      }
      Debug.Log(bosses.Length);
      if (bosses.Length != 0) {Destroy(bosses[0]);};
      boss_was_spawned = false;

    }

    void Start() {
        Reset();
        bossHealthImage.enabled = false;
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        bosses = GameObject.FindGameObjectsWithTag("Boss");
        enemyCount = enemies.Length;
        bossCount = bosses.Length;
        boss_is_alive = bossCount != 0;

        // keep track of stage
        if (Time.time - startTime > cur_stage*30f) {
          cur_stage += 1;
          MAX_ENEMIES = (int) ((float) MAX_ENEMIES * 1.25f);
          // new enemy type
          if (availEnemyPrefabs.Count < EnemyPrefabs.Length && cur_stage == new_enemy_stage) {
            availEnemyPrefabs.Add(EnemyPrefabs[availEnemyPrefabs.Count]);
            new_enemy_stage += 2;
            Debug.Log("new enemy added");
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
        if (Time.time - startTime > 30f && boss_was_spawned != true) {
            SpawnAnEnemy(BossPrefabs[0]);
            boss_was_spawned = true;
            bossHealthImage.enabled = true;
            Debug.Log("Boss spawned!");
        }

        DisplayTimer();
    }

    private void DisplayTimer()
    {

        float t = Time.time - startTime;
        float min = Mathf.Floor(t / 60);
        float sec = Mathf.Round(t % 60);
        string minutes;
        string seconds;

        if(min < 10)
        {
            minutes = "0" + min.ToString();
        }
        else
        {
            minutes = min.ToString();
        }

        if(sec < 10)
        {
            seconds = "0" + Mathf.RoundToInt(sec).ToString();
        }
        else
        {
            seconds = sec.ToString();
        }

        timer.text = minutes.ToString() + ":" + seconds;
        timerText = timer.text;
    }
    void SpawnRandomEnemy() {

        // choose what enemy to spawn
        int enemyIndex = Random.Range(0, availEnemyPrefabs.Count);
        GameObject enemy_to_spawn = availEnemyPrefabs[enemyIndex];
        SpawnAnEnemy(enemy_to_spawn);
    }

    void SpawnAnEnemy(GameObject enemy_to_spawn) {
      playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
      int player_x = (int) playerPos.x;
      int player_y = (int) playerPos.y;
      // spawn close enough, but not too close to player
      Vector2 spawnPos;
      int xPos;
      int yPos;
      do {
        xPos = Random.Range(player_x- 15, player_x+ 15);
        yPos = Random.Range(player_y- 15, player_y+ 15);
        spawnPos = new Vector2(xPos, yPos);
      } while (Vector2.Distance(spawnPos, playerPos) < min_spawn_distance
                || xPos < MIN_X || xPos > MAX_X || yPos < MIN_Y || yPos > MAX_Y
              );

      Instantiate(enemy_to_spawn, spawnPos, Quaternion.identity);
    }

    // void SpawnAnEnemy2(GameObject enemyToSpawn)
    // {
    //     int maxAttempts = 100;
    //     int attempts = 0;
    //     bool enemySpawned = false;
    //
    //     playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    //     int player_x = (int)playerPos.x;
    //     int player_y = (int)playerPos.y;
    //
    //     while (!enemySpawned && attempts < maxAttempts)
    //     {
    //         Vector2 spawnPos;
    //         do
    //         {
    //             int xPos = Random.Range(player_x - 15, player_x + 15);
    //             int yPos = Random.Range(player_y - 15, player_y + 15);
    //             spawnPos = new Vector2(xPos, yPos);
    //         } while (Vector2.Distance(spawnPos, playerPos) < min_spawn_distance);
    //
    //
    //         Collider2D enemyCollider = enemyToSpawn.GetComponent<Collider2D>();
    //         Vector2 enemyColliderSize = enemyCollider.size;
    //
    //         Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPos, enemyColliderSize, 0);
    //
    //         if (colliders.Length == 0)
    //         {
    //             Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
    //             enemySpawned = true;
    //         }
    //
    //         else
    //         {
    //             bool hitBoundary = false;
    //
    //             foreach (Collider2D collider in colliders)
    //             {
    //                 if (collider.CompareTag("MapBoundary"))
    //                 {
    //                     hitBoundary = true;
    //                     break;
    //                 }
    //             }
    //
    //             if (!hitBoundary)
    //             {
    //                 Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
    //                 enemySpawned = true;
    //             }
    //         }
    //         attempts++;
    //     }
    //
    // }

}
