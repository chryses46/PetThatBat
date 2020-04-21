using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    [SerializeField] ScoreColumn[] scoreColumns;

    [SerializeField] GameObject continueText;

    bool columnsInitialized;

    bool isTimerRunning;

    float startingTime = 0;

    int columnsAnimated = 0;

    private void Update()
    {
        if(columnsInitialized)
        {
            AnimateColumns();
        }

        if (isTimerRunning)
            IterateSeconds();
    }

    public void InitializeColumns(Player[] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            scoreColumns[i].InitializeColumn(players[i].GetScore(), players[i].GetPlayerSprite());
        }

        columnsInitialized = true;

        ToggleTimer(true);
    }

    private void AnimateColumns()
    {
        for (int i = 0; i < scoreColumns.Length; i++)
        {
            scoreColumns[i].AnimateColumn(startingTime);

            if(scoreColumns[i].GetAnimationCompletionStatus())
            {
                columnsAnimated += 1;
            }
        }

        if(columnsAnimated == scoreColumns.Length)
        {
            EnableContinue();
        }
    }

    private void EnableContinue()
    {
        continueText.SetActive(true);

        FindObjectOfType<GameOverlord>().SetCurrentGameMode(GameOverlord.GameMode.ENDGAME);
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
