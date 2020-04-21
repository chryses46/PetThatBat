using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    [SerializeField] float startAnimationAfterSeconds;

    Animator animator;

    private bool isTimerRunning;
    private float startingTime = 0;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();

        ToggleTimer(true);
    }

    public void Update()
    {
        if(isTimerRunning)
        {
            IterateSeconds();
        }

        if(startingTime > startAnimationAfterSeconds)
        {
            animator.SetTrigger("beginMove");
            ToggleTimer(false);
            startingTime = 0;
        }
    }

    public void StartRotating()
    {
        gameObject.GetComponent<Animator>().SetBool("inPosition", true);
    }


    private void ToggleTimer(bool isRunning)
    {
        isTimerRunning = isRunning;
    }

    private void IterateSeconds()
    {
        startingTime += Time.deltaTime;
    }
}
