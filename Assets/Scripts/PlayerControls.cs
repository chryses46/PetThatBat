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

    [SerializeField] private Player[] activePlayers = {null,null,null,null};

    private void Start()
    {
        gameOverlord = FindObjectOfType<GameOverlord>();

        SetActivePlayers();

    }

    public void Update()
    {
        // Actually, first run check for keyboard vs controller.
        if (gameOverlord.GetCurrentGameMode() == "PLAY" )
        {
            KeyboardControls();
        }

        if(gameOverlord.GetCurrentReleaseSetting() == "Cabinet" & Input.GetKeyDown(KeyCode.C))
        {
            Application.Quit();
        }

        DevControls();
    }

    private void KeyboardControls()
    {
        // control if key already pressed
        if (activePlayers[0] != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                activePlayers[0].PettingAction(true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                activePlayers[0].PettingAction(false);
            }
        }

        if (activePlayers[1] != null)
        {
            if (Input.GetKey(KeyCode.F))
            {
                activePlayers[1].PettingAction(true);
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                activePlayers[1].PettingAction(false);
            }
        }

        if (activePlayers[2] != null)
        {
            if (Input.GetKey(KeyCode.J))
            {
                activePlayers[2].PettingAction(true);
            }
            else if (Input.GetKeyUp(KeyCode.J))
            {
                activePlayers[2].PettingAction(false);
            }
        }

        if (activePlayers[3] != null)
        {
            if (Input.GetKey(KeyCode.L))
            {
                activePlayers[3].PettingAction(true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                activePlayers[3].PettingAction(false);
            }
        }
    }

    private void SetActivePlayers()
    {
        Player[] players = FindObjectsOfType<Player>();

        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].IsActive())
            {
                activePlayers[players[i].GetPlayerNumber() - 1] = players[i];
            }
        }
    }

    public Player[] GetActivePlayers()
    {
        return activePlayers;
    }

    private void DevControls()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            FindObjectOfType<Bat>().ToggleSleepAndAwake();
        }
    }
}
