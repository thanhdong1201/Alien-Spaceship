using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("EnemyType")]
    public GameObject[] enemyPrefab;
    public Transform[] spawnPosition;
    private Transform randomSpawnPosition;

    [Header("Boss")]
    public GameObject bossPrefab;
    public Transform bossSpawnPosition;

    [Header("Time")]
    public float timer;
    private float spawnEnemytime;
    private bool spawned = false;
    private int random;

    private void Start()
    {
        spawnEnemytime = Random.Range(1, 4);
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        spawnEnemytime -= Time.deltaTime;
        
        if (timer > 0)
        {
            if (spawnEnemytime <= 0)
            {
                Spawn();
                spawnEnemytime = Random.Range(3, 6);
            }
        }
        if (timer <= 0)
        {
            SpawnBoss();
            timer = 0;
        }

    }

    private void SpawnBoss()
    {     
        if (!spawned)
        {        
            Instantiate(bossPrefab, bossSpawnPosition.position, bossSpawnPosition.rotation);
            spawned = true;
        }
    }

    private void Spawn()
    {
        randomSpawnPosition = spawnPosition[Random.Range(0, spawnPosition.Length)].transform;
        random = Random.Range(0, 11);

        if (random <= 3)
        {
            Instantiate(enemyPrefab[0], randomSpawnPosition.position, randomSpawnPosition.rotation);
        }
        if (random > 3 && random <= 6)
        {
            Instantiate(enemyPrefab[1], randomSpawnPosition.position, randomSpawnPosition.rotation);
        }
        if (random > 6 && random <= 8)
        {
            Instantiate(enemyPrefab[2], randomSpawnPosition.position, randomSpawnPosition.rotation);
        }
        if (random == 9)
        {
            Instantiate(enemyPrefab[3], randomSpawnPosition.position, randomSpawnPosition.rotation);
        }
    }
}
