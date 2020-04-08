using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    PlayerControls playerControls;

    [SerializeField] Player[] players;

    [SerializeField] private GameObject[] playerScoreWrappers;

    [SerializeField] private Text[] playerScoreDisplays;

    private int totalPlayerScore = 0;

    private void Start()
    {
        playerControls = FindObjectOfType<PlayerControls>();
        players = playerControls.GetActivePlayers();

        EnablePlayerScoreWrappers();
    }

    private void Update()
    {
        KeepScore();
    }

    private void KeepScore()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i] != null)
            {
                int score = players[i].GetScore();

                playerScoreDisplays[i].text = score.ToString();

                totalPlayerScore += score;
            }
        }
    }

    private void EnablePlayerScoreWrappers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i] != null)
            {
                playerScoreWrappers[i].SetActive(true);
            }
        }
    }

    public Player[] GetPettingPlayers()
    {
        Player[] pettingPlayers = { null,null,null,null };

        for (int i = 0; i < players.Length; i++)
        {
            if(players[i] != null && players[i].IsPetting())
            {
                pettingPlayers[i] = players[i];
            }
        }

        return pettingPlayers;
    }

    public int GetTotalPlayerScore()
    {
        return totalPlayerScore;
    }

 }
