using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private GameObject powerPrefab;
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Player>().AddPower(powerPrefab);
            Destroy(gameObject);
        }
    }
}
