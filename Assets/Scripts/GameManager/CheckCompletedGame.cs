using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompletedGame : MonoBehaviour
{
    [SerializeField] private GameEvent onCompletedGame;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onCompletedGame?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
