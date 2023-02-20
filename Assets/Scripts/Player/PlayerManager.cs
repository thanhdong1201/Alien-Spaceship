using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private int alives;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private TextMeshProUGUI alivesCount;
    [Header("Event")]
    [SerializeField] private GameEvent onGameOver;

    private bool canRespawn = true;
    private float timer = 3f;

    public void RespawnPlayer()
    {
        alives -= 1;
        if (alives > 0)
        {
            if (canRespawn)
            {
                this.Wait(waitTime, () => { Instantiate(playerPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation); });   
                canRespawn = false;               
            }       
        }    
    }

    private void Update()
    {
        alivesCount.SetText("live: " + alives);
        if (alives <= 0)
        {
            onGameOver?.Invoke();
            alives = 0;
        }

        if (!canRespawn)
        {   
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                canRespawn = true;
                timer = 3f;
            }
        }
    }
}
