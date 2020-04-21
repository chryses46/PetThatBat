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

    [SerializeField] private Player[] activePlayers;

    Player
        player1,
        player2,
        player3,
        player4;

    private void Start()
    {
        gameOverlord = GetComponent<GameOverlord>();

    }

    public void Update()
    {
        if(gameOverlord.GetCurrentReleaseSetting() == "Cabinet" & Input.GetKeyDown(KeyCode.C))
        {
            Application.Quit();
        }

        // Actually, first run check for keyboard vs controller.
        if (gameOverlord.GetCurrentGameMode() == "PLAY" )
        {
            KeyboardControls();
        }
        else if(gameOverlord.GetCurrentGameMode() == "START")
        {
            if(Input.anyKeyDown)
            {
                gameOverlord.LoadPlayerSelect();
            }
        }
        else if(gameOverlord.GetCurrentGameMode() == "ENDGAME")
        {
            if (Input.anyKeyDown)
            {
                gameOverlord.LoadStartScreen();
            }
        }

        

        DevControls();
    }

    private void KeyboardControls()
    {
        // control if key already pressed
        if (player1 && player1.IsActive())
        {
            if (Input.GetKey(KeyCode.A))
            {
                player1.PettingAction(true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                player1.PettingAction(false);
            }
        }

        if (player2 && player2.IsActive())
        {
            if (Input.GetKey(KeyCode.F))
            {
                player2.PettingAction(true);
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                player2.PettingAction(false);
            }
        }

        if (player3 && player3.IsActive())
        {
            if (Input.GetKey(KeyCode.J))
            {
                player3.PettingAction(true);
            }
            else if (Input.GetKeyUp(KeyCode.J))
            {
                player3.PettingAction(false);
            }
        }

        if (player4 && player4.IsActive())
        {
            if (Input.GetKey(KeyCode.L))
            {
                player4.PettingAction(true);
            }
            else if (Input.GetKeyUp(KeyCode.L))
            {
                player4.PettingAction(false);
            }
        }
    }

    public void EnableDisablePlayerControls(Player player)
    {
        int playerNumber = player.GetPlayerNumber();

        switch (playerNumber)
        {
            case 1:
                player1 = player;
                break;
            case 2:
                player2 = player;
                break;
            case 3:
                player3 = player;
                break;
            case 4:
                player4 = player;
                break;
            default:
                break;
        }
    }

    public void SetActivePlayers()
    {
        activePlayers = new Player[FindObjectsOfType<Player>().Length];

        activePlayers = FindObjectsOfType<Player>();


        for (int i = 0; i < activePlayers.Length; i++)
        {
            EnableDisablePlayerControls(activePlayers[i]);
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
