using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Begin by detecting controllers
    // require XInput

    // if controllers
    // run controller controls
    // else

    GameOverlord gameOverlord;

    private bool pressed;

    private void Start()
    {
        gameOverlord = FindObjectOfType<GameOverlord>();
    }

    public void Update()
    {
        // Actually, first run check for keyboard vs controller.
        if (gameOverlord.GetCurrentGameMode() == "PLAY")
        {
            KeyboardControls();
        }
    }

    private void KeyboardControls()
    {
        // control if key already pressed
        if(Input.GetKey(KeyCode.Z))
        {
            Debug.Log("player1");
           
        }
    }




}
