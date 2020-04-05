using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    GameOverlord gameOverlord;

    [SerializeField] Player[] players;

    [SerializeField] GameObject pressWhenReady;

    [SerializeField] GameObject pressWhenReadyArcade;

    [SerializeField] GameObject pressWhenReadyMobile;

    [SerializeField] GameObject[] interactWrappers;

    [SerializeField] GameObject[] playerReadyWrappers;

    private bool isPCRelease;
    private bool isCABRelease;
    private bool isMobileRelease;

    private bool isWhenReadyActive;

    void Start()
    {
        gameOverlord = FindObjectOfType<GameOverlord>();

        DetermineRelease();
    }

    void Update()
    {
        PlayerSelectionControl();

        CheckIfEnoughPlayers();

        if(isWhenReadyActive)
        {
            AllPlayersReady();
        }
    }

    private void AllPlayersReady()
    {
        if(isCABRelease)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Return))
            {
                gameOverlord.StartGame();
            }
        }
        else if(isMobileRelease)
        {
            // mobile control stuff
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                gameOverlord.StartGame();
            }
        }
    }

    // Will also need a mobile
    private void CheckIfEnoughPlayers()
    {
        if(gameOverlord.GetNumPlayers() > 0)
        {
            if(!isWhenReadyActive)
            {
                if(isCABRelease)
                {
                    pressWhenReadyArcade.SetActive(true);
                }
                else if(isMobileRelease)
                {
                    pressWhenReadyMobile.SetActive(true);
                }
                else
                {
                    pressWhenReady.SetActive(true);
                }

                isWhenReadyActive = true;
            }
            
            
        }
        else if(gameOverlord.GetNumPlayers() < 1)
        {
            if (isWhenReadyActive)
            {
                if (isCABRelease)
                {
                    pressWhenReadyArcade.SetActive(false);
                }
                else if (isMobileRelease)
                {
                    pressWhenReadyMobile.SetActive(false);
                }
                else
                {
                    pressWhenReady.SetActive(false);
                }

                isWhenReadyActive = false;
            }
        }
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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Enable Player 1.");
                EnablePlayer(0);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Enable Player 2.");
                EnablePlayer(1);
            }

            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                Debug.Log("Enable Player 3.");
                EnablePlayer(2);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Enable Player 4.");
                EnablePlayer(3);
            }
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

            interactWrappers[playerIndex].SetActive(false);

            playerReadyWrappers[playerIndex].SetActive(true);

            gameOverlord.AddRemovePlayer(1);
        }
        else
        {
            players[playerIndex].gameObject.SetActive(false);

            playerReadyWrappers[playerIndex].SetActive(false);

            interactWrappers[playerIndex].SetActive(true);

            gameOverlord.AddRemovePlayer(-1);
        }
    }
}
