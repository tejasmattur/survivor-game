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

    private float nextBossSpawn = 30f;
    private int bossIdx = 0;

    // constants
    private int MAX_X = 15;
    private int MIN_X = -110;
    private int MAX_Y = 17;
    private int MIN_Y = -45;

    // Time

    public TMP_Text timer;
    private float startTime;
    public float endTime;

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
          MAX_ENEMIES = (int) ((float) MAX_ENEMIES * 1.35f);
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

        // Spawn Boss
        if (Time.time - startTime > nextBossSpawn) {
            SpawnAnEnemy(BossPrefabs[bossIdx]);
            boss_was_spawned = true;
            bossHealthImage.enabled = true;
            Debug.Log("Boss spawned!");
            nextBossSpawn += 45f;
            if (bossIdx < BossPrefabs.Length-1) {
              bossIdx += 1;
            }
            else {
              bossIdx = 0;
            }
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
        endTime = t;
    }


    void SpawnRandomEnemy() {

        // choose what enemy to spawn
        int enemyIndex = Random.Range(0, availEnemyPrefabs.Count);
        GameObject enemy_to_spawn = availEnemyPrefabs[enemyIndex];
        SpawnAnEnemy(enemy_to_spawn);
    }

    void SpawnAnEnemy(GameObject enemy_to_spawn) {

      // spawn close enough, but not too close to player
      Vector2 spawnPos = getRandomPosNearPlayer(3, 15);
      Instantiate(enemy_to_spawn, spawnPos, Quaternion.identity);
      //enemy_to_spawn.transform.parent = grid.transform;
    }

    public Vector2 getRandomPosNearPlayer(float min_spawn_distance, int offset) {
      playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
      int player_x = (int) playerPos.x;
      int player_y = (int) playerPos.y;

      Vector2 spawnPos;
      int xPos;
      int yPos;
      do {
        xPos = Random.Range(player_x- offset, player_x+ offset);
        yPos = Random.Range(player_y- offset, player_y+ offset);
        spawnPos = new Vector2(xPos, yPos);
      } while (Vector2.Distance(spawnPos, playerPos) < min_spawn_distance
                || xPos < MIN_X || xPos > MAX_X || yPos < MIN_Y || yPos > MAX_Y
              );

      return spawnPos;
    }


}
