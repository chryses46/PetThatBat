using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int playerNumber;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private int points;

    public void PettingAction(bool isPetting)
    {
        animator.SetBool("isPetting", isPetting);

        if(isPetting)
        {
            points++;
        }
    }
}
