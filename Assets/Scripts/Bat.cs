using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    Animator animator;

    enum BatState
    {
        WAITING,
        SLEEPING,
        WOKEN
    }

    BatState batstate = BatState.WAITING;

    int roundNumber = 0;

    private bool isSleeping;

    private float startingTime = 0;

    private float secondsUntilSleeping = 3;

    [SerializeField] private float minimumSecondsToSleep = 10;

    [SerializeField] private float maximumSecondsToSleep = 20;

    private float secondsUntilWoken;

    [SerializeField] private float minimumStartleWindowInSeconds = 1;

    [SerializeField] private float maximumStartleWindowInSeconds = 5;

    private bool isStartling;

    private float timeSinceLastStartle = 0;

    private bool isTimerRunning;

    private bool isGameOver = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        ToggleTimer(true);

    }

    private void Update()
    {
        if(!isSleeping && isTimerRunning && startingTime >= secondsUntilSleeping)
        {
            ToggleTimer(false);

            startingTime = 0;

            BatNapTime();
        }
        else if(isSleeping)
        {
            if(startingTime >= secondsUntilWoken)
            {  
                WokeBat();
            }
            else
            {
                StartleTimeDetermination();
            }
        }

        if(isGameOver)
        {
            GameOver();
        }

        if (isTimerRunning)
        {
            IterateSeconds();
        }
    }

    private void SleepingBat(bool isSleeping)
    {
        animator.SetBool("isSleeping", isSleeping);

        batstate = BatState.SLEEPING;

        this.isSleeping = isSleeping;

        ToggleTimer(isSleeping);
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

    private void BatNapTime()
    {
        // iterate round number
        roundNumber += 1;

        Debug.Log("Round " + roundNumber);

        //possible chance to display round number.
            // set round number
            // call animator for round number display (or put at the start of "blink to sleep" for ease

        // Play blinkToSleep animation
        animator.SetTrigger("blinkToSleep");// Sets isSleeping animation boolean to true at end of blinkToSleep anim

        // Determine when the bat will awaken (total score % based on # of players method) - 
        // Currently hard set to: min 10secs, max 20secs
        secondsUntilWoken = UnityEngine.Random.Range(minimumSecondsToSleep, maximumSecondsToSleep);
    }

    private void WokeBat()
    {
        int playersStillPlaying = 0;

        Player[] players = FindObjectsOfType<Player>();

        for (int i = 0; i < players.Length; i++)
        {

            if (players[i].IsPetting())
            {
                players[i].DisabledThisRound();
            }
            else
            {
                playersStillPlaying += 1;
            }
        }

        ToggleSleepAndAwake();

        batstate = BatState.WOKEN;

        if (playersStillPlaying > 0)
        {
            PlayAgain();
        }
        else
        {
            isGameOver = true;
        }
    }

    private void PlayAgain()
    {
        secondsUntilSleeping = 3;

        ToggleTimer(true);

        startingTime = 0;

        batstate = BatState.WAITING;
    }

    private void GameOver()
    {
        int playersWithdrawn = 0;

        Player[] players = FindObjectsOfType<Player>();

        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].isWithdrawn())
            {
                playersWithdrawn += 1;
            }
        }
        
        if(playersWithdrawn == players.Length)
        {
            FindObjectOfType<GameOverlord>().GameOver();

            isGameOver = false;
        }
    }

    private void StartleTimeDetermination()
    {
        if(!isStartling)
        {
            timeSinceLastStartle += Time.deltaTime;
        }
        

        if (timeSinceLastStartle >= 2 && !isStartling)
        {
            isStartling = true;

            float secondsUntilNextStartle = UnityEngine.Random.Range(minimumStartleWindowInSeconds, maximumStartleWindowInSeconds);

            StartCoroutine(StartleBat(secondsUntilNextStartle));
        }
    }

    IEnumerator StartleBat(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if(isSleeping)
        {
            animator.SetTrigger("startled");
        }

        timeSinceLastStartle = 0;

        isStartling = false;
    }

    private void ToggleTimer(bool isRunning)
    {
        isTimerRunning = isRunning;
    }

    private void IterateSeconds()
    {
        startingTime += Time.deltaTime;
    }

    public void SetSecondsUntilSleeping(int seconds)
    {
        secondsUntilSleeping = seconds;
    }

    public void SetSecondsToSleep(float min, float max)
    {
        minimumSecondsToSleep = min;

        maximumSecondsToSleep = max;
    }

    public void SetStartleWindowInSeconds(float min, float max)
    {
        minimumStartleWindowInSeconds = min;

        maximumStartleWindowInSeconds = max;
    }

    public bool isBatSleeping()
    {
        return isSleeping;
    }

    public String GetBatState()
    {
        switch (batstate)
        {
            case BatState.WAITING:
                return "WAITING";
            case BatState.SLEEPING:
                return "SLEEPING";
            case BatState.WOKEN:
                return "WOKEN";
        }

        return "Something went wrong.";
    }
}
