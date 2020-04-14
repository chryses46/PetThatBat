using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSeclectWrapper : MonoBehaviour
{
    [SerializeField] Sprite arcadeButton;
    
    [SerializeField] Sprite pcButton;

    [SerializeField] SVGImage buttonImage;

    private void Awake()
    {
        if(FindObjectOfType<GameOverlord>().GetCurrentReleaseSetting() == "Cabinet")
        {
            buttonImage.sprite = arcadeButton;
        }
        else if(FindObjectOfType<GameOverlord>().GetCurrentReleaseSetting() == "PC")
        {
            buttonImage.sprite = pcButton;
        }
    }
}
