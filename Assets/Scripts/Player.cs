using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int playerNumber;

    Animator animator;

    private bool isActive;

    private int score;

    private bool isPetting;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        isActive = true;
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
        animator.SetBool("isPetting", isPetting);

        this.isPetting = isPetting;

        if(isPetting)
        {
            score++;
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
}
