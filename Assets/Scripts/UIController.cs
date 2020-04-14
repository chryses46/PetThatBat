using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas titleScreen;

    [SerializeField] private Canvas playerSelectMenu;

    [SerializeField] private Canvas playMenuCanvas;

    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private Image transitioner;

    GameOverlord gameOverlord;

    private void Start()
    {
        gameOverlord = GetComponent<GameOverlord>();
    }

    public void EnableTitleScreen(bool enabled)
    {
        //TriggerTransitioner(enabled);

        titleScreen.gameObject.SetActive(enabled);
    }

    public void EnablePlayerSelectMenu(bool enabled)
    {
        //TriggerTransitioner(enabled);

        playerSelectMenu.gameObject.SetActive(enabled);        
    }

    public void EnablePlayCanvas(bool enabled)
    {
        playMenuCanvas.gameObject.SetActive(enabled);
    }

    public void EnableGameOverScreen(bool enabled)
    {
        gameOverScreen.SetActive(enabled);
    }

    
    public void TriggerTransitioner(bool isFadingIn)
    {
        Debug.Log("Fader Triggered");

        Color transitionerColor = transitioner.color;

        switch (isFadingIn)
        {
            case true:
                Color inStartColor = new Color(transitionerColor.r, transitionerColor.g, transitionerColor.b, 0);
                transitioner.color = inStartColor;
                transitioner.GetComponent<Animator>().SetTrigger("fadeIn");
                break;
            case false:
                Color outStartColor = new Color(transitionerColor.r, transitionerColor.g, transitionerColor.b, 255);
                transitioner.color = outStartColor;
                transitioner.GetComponent<Animator>().SetTrigger("fadeOut");
                break;

        }


    }
}
