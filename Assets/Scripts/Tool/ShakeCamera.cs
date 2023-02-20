using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] private float shakeTime;
    private Animator anim;  

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Shake()
    {
        anim.SetBool("isShaking", true);
        this.Wait(shakeTime, () => { anim.SetBool("isShaking", false); });
    }
}
