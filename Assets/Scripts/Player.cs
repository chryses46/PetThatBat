﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int playerNumber;

    [SerializeField] GameObject caught;

    Animator animator;

    private bool isActive;

    private int score;

    private bool isPetting;

    private string petAnimationIdentifier;

    private int numTimesStoppedPetting;

    private bool withdrawn;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        isActive = true;

        petAnimationIdentifier = "player" + playerNumber + "IsPetting";
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void PettingAction(bool isPetting)
    {
        if (isActive)
        {
            animator.SetBool(petAnimationIdentifier, isPetting);

            this.isPetting = isPetting;

            if (isPetting && FindObjectOfType<Bat>().isBatSleeping())
            {
                score++;
            }

            if (!isPetting)
            {
                numTimesStoppedPetting += 1;
            }
        }
    }

    public bool IsPetting()
    {
        return isPetting;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public void DisabledThisRound()
    {
        animator.SetBool(petAnimationIdentifier, false);
        
        isActive = false;

        caught.SetActive(true);
    }

    public void Withdrawl()
    {
        animator.SetTrigger("withdrawl"+playerNumber);
    }

    public void SetWithdawn()
    {
        withdrawn = true;
    }

    public bool isWithdrawn()
    {
        return withdrawn;
    }

    public int GetNumTimesStoppedPetting()
    {
        return numTimesStoppedPetting;
    }
}
