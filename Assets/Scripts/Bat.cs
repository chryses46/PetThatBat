using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    Animator animator;

    private bool isSleeping;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void SleepingBat(bool isSleeping)
    {
        animator.SetBool("isSleeping", isSleeping);

        this.isSleeping = isSleeping;
    }



    public void ToggleSleepAndAwake()
    {
        if(isSleeping)
        {
            SleepingBat(false);
        }
        else
        {
            SleepingBat(true);
        }
    }
}
