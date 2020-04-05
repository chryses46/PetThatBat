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

        if(isPetting)
        {
            score++;
        }
    }

    public int GetScore()
    {
        return score;
    }
}
