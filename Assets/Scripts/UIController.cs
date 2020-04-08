using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas;

    [SerializeField] private Image playerSelectMenu;

    [SerializeField] private Canvas playMenuCanvas;

    [SerializeField] private GameObject gameOverScreen;

    GameOverlord gameOverlord;

    private void Start()
    {
        gameOverlord = GetComponent<GameOverlord>();
    }

    public void EnableMainMenuCanvas(bool enabled)
    {
        mainMenuCanvas.gameObject.SetActive(enabled);
    }

    public void EnablePlayerSelectMenu(bool enabled)
    {
        playerSelectMenu.gameObject.SetActive(enabled);
    }

    public void EnablePlayCanvas(bool enabled)
    {
        playMenuCanvas.gameObject.SetActive(enabled);
    }

    public void EnableGameOverScreen(bool enabled)
    {
        gameOverScreen.SetActive(true);
    }
}
