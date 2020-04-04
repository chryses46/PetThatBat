using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Image pcPlayerSelectMenu;
    [SerializeField] private Image cabinetPlayerSelectMenu;
    [SerializeField] private Image mobilePlayerSelectMenu;

    [SerializeField] private Canvas playMenuCanvas;

    public void EnableMainMenuCanvas(bool enabled)
    {
        // enable the main menu canvas object
    }

    public void EnablePlayerSelectMenu(bool enabled)
    {

    }

    public void EnablePlayCanvas(bool enabled)
    {
        // enable the play canvas
    }

}
