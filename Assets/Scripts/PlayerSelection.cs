using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    GameOverlord gameOverlord;

    [SerializeField] Player[] players;

    private bool isPCRelease;
    private bool isCABRelease;
    private bool isMobileRelease;

    void Start()
    {
        gameOverlord = FindObjectOfType<GameOverlord>();

        DetermineRelease();
    }

    void Update()
    {
        PlayerSelectionControl();
    }

    private void DetermineRelease()
    {
        switch(gameOverlord.GetCurrentReleaseSetting())
        {
            case "PC":
                isPCRelease = true;
                break;
            case "Cabinet":
                isCABRelease = true;
                break;
            case "Mbile":
                isMobileRelease = true;
                break;

        }
    }

    private void PlayerSelectionControl()
    {
        if (isPCRelease)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Enable Player 1.");
                EnablePlayer(0);
                
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Enable Player 2.");
                EnablePlayer(1);
            }

            if(Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("Enable Player 3.");
                EnablePlayer(2);
            }

            if(Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Enable Player 4.");
                EnablePlayer(3);
            }
        }
        else if (isCABRelease)
        {
            // if key Z hit
                // enalbe player 1
            // if key A hit
                // enable player 2
            // if key [ hit
                // enable player 3
            // if key B hit
                // enable player 4
        }
        else if (isMobileRelease)
        {
            // if quadrant 3 tapped
                // enalbe player 1
            // if quadrant 4 tapped 
                // enable player 2
            // if quadrant 2 tapped
                // enable player 3
            // if quadrant 1 tapped
                // enable player 4
        }

    }

    private void EnablePlayer(int playerIndex)
    {
        if (players[playerIndex].gameObject.activeSelf == false)
        {
            players[playerIndex].gameObject.SetActive(true);
        }
        else
        {
            players[playerIndex].gameObject.SetActive(false);
        }
    }
}
