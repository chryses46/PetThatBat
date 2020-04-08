using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    Animator animator;

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


        if (isTimerRunning)
        {
            IterateSeconds();
        }
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

    private void BatNapTime()
    {
        // Play blinkToSleep animation
        animator.SetTrigger("blinkToSleep");

        // Set isSleeping animation boolean to true
        SleepingBat(true);

        // Determine when the bat will awaken (total score % based on # of players method) - 
        // Currently hard set to: min 10secs, max 20secs
        secondsUntilWoken = UnityEngine.Random.Range(minimumSecondsToSleep, maximumSecondsToSleep);

        Debug.Log("The bat will sleep for " + secondsUntilWoken + " seconds.");

        ToggleTimer(true);

    }

    private void WokeBat()
    {
        Player[] currentlyPettingPlayers = FindObjectOfType<ScoreBoard>().GetPettingPlayers();

        for (int i = 0; i < currentlyPettingPlayers.Length; i++)
        {
            if(currentlyPettingPlayers[i] != null)
                currentlyPettingPlayers[i].SetScore(0);
        }

        Player[] activePlayers = FindObjectOfType<PlayerControls>().GetActivePlayers();

        int playersStillPlaying = 0;

        for (int i = 0; i < activePlayers.Length; i++)
        {
            if(activePlayers[i] != null)
            {
                if(activePlayers[i].GetScore() > 0)
                {
                playersStillPlaying += 1;
                }
            }
            
        }

        SleepingBat(false);

        ToggleTimer(false);

        if (playersStillPlaying > 0)
        {
            PlayAgain();
        }
        else
        {
            GameOver();
        }
    }

    private void PlayAgain()
    {
        // here we sould do some kind of recognition that the players who will continue to play, will
        Debug.Log("Yay! We play again. More info here..");

        secondsUntilSleeping = 3;

        ToggleTimer(true);

        startingTime = 0;
    }

    private void GameOver()
    {
        FindObjectOfType<GameOverlord>().GameOver();
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

            Debug.Log("There will be " + secondsUntilNextStartle + " seconds before the next startling of the bat.");

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
}
