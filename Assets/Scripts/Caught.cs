using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour
{
    [SerializeField] Player linkedPlayer;

    private void Awake()
    {
        GetComponent<Animator>().SetTrigger("wasCaught");
    }


    public void DisableThis()
    {
        gameObject.SetActive(false);

        linkedPlayer.Withdrawl();
    }
}
