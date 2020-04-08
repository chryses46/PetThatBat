using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;

    [SerializeField] GameObject playerTotalScores;

    private void Awake()
    {

    }

    private void ShowGameOverText()
    {
        //animation that fades the GAME OVER text up and then fades out

    }

    private void PopulatePlayerTotalScores()
    {
        // gets each active player
        // sets each player's high score to the player score box at their corresponding quadrant

    }
}
