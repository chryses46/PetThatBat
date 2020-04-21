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
            int score = players[i].GetScore();

            playerScoreDisplays[players[i].GetPlayerNumber() - 1].text = score.ToString();

            totalPlayerScore += score;
        }
    }

    private void EnablePlayerScoreWrappers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            playerScoreWrappers[players[i].GetPlayerNumber() - 1].SetActive(true);
        }
    }

    public int GetTotalPlayerScore()
    {
        return totalPlayerScore;
    }

 }
