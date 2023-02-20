using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;

    public void EnableBox()
    {
        boxCollider2D.isTrigger = false;
    }
    public void DisableBox()
    {
        boxCollider2D.isTrigger = true;
    }
}
