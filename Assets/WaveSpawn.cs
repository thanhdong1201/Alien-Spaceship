using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [Header("Boss")]
    public GameObject bossPrefab;
    public Transform bossSpawnPosition;

    [Header("Time")]
    public float timer;
    private bool spawned = false;

    private void LateUpdate()
    {
        timer -= Time.deltaTime;

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
}
