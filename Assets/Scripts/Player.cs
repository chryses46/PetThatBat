using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int playerNumber;

    [SerializeField] GameObject caught;

    [SerializeField] Sprite playerSprite;

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
            this.isPetting = isPetting;

            if (isPetting && FindObjectOfType<Bat>().GetBatState() == "SLEEPING") // Change to check for BatState.SLEEPING
            {
                animator.SetBool(petAnimationIdentifier, isPetting);

                score++;
            }
            else if(!isPetting)
            {
                animator.SetBool(petAnimationIdentifier, isPetting);
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

    public Sprite GetPlayerSprite()
    {
        return playerSprite;
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
