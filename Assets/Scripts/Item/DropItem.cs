using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject[] itemPrefab;

    public void Drop()
    {
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, transform.rotation);
    }
}
