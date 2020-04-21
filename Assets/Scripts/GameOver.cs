using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;

    [SerializeField] ScoreHolder[] scoreHolders;

    [SerializeField] int[] playerScores;

    private void Awake()
    {
        //ShowGameOverText();
    }

    private void ShowGameOverText()
    {
        gameOverText.SetActive(true);
    }

    public void PopulatePlayerTotalScores()
    {
        //get active players
        Player[] activePlayers = FindObjectOfType<PlayerControls>().GetActivePlayers();

        //sort score from highest to lowest into scores array
        //int[] scores = new int[activePlayers.Length];

        int highestScore;
        Player highestScoringPlayer, oldHighScoringPlayer;

        for (int i = 0; i < activePlayers.Length - 1; i++)
        {
            highestScore = activePlayers[i].GetScore();
            highestScoringPlayer = activePlayers[i];

            for (int j = i + 1; j < activePlayers.Length; j++)
            {
                int comparisonScore = activePlayers[j].GetScore();

                if ( comparisonScore > highestScore)
                {
                    highestScore = comparisonScore;
                    oldHighScoringPlayer = highestScoringPlayer;
                    highestScoringPlayer = activePlayers[j];
                    activePlayers[j] = oldHighScoringPlayer;
                }
            }

            activePlayers[i] = highestScoringPlayer;
        }

        for (int i = 0; i < activePlayers.Length; i++)
        {
            Debug.Log("Player rank " + (i + 1) + " is " + activePlayers[i].name + " with a score of " + activePlayers[i].GetScore());
        }
        // place highest in 1st place, 2nd highest in 2nd and so on

        // enable the right scoreBoard based on number of players
        switch (activePlayers.Length)
        {
            case 1:
                scoreHolders[0].gameObject.SetActive(true);
                scoreHolders[0].InitializeColumns(activePlayers);
                break;
            case 2:
                scoreHolders[1].gameObject.SetActive(true);
                scoreHolders[1].InitializeColumns(activePlayers);
                break;
            case 3:
                scoreHolders[2].gameObject.SetActive(true);
                scoreHolders[2].InitializeColumns(activePlayers);
                break;
            case 4:
                scoreHolders[3].gameObject.SetActive(true);
                scoreHolders[3].InitializeColumns(activePlayers);
                break;
            default:
                break;
        }
    }
}
