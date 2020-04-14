using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SVGAnimate : MonoBehaviour
{
    [SerializeField] SVGImage svgImageObject;

    [SerializeField] Sprite[] animationSprites;

    [SerializeField] float secondsBetweenBlinks = 4;

    [SerializeField] float secondsToOpenEyes = 1f;

    private bool isTimerRunning;

    private float startingTime;

    private void Awake()
    {
        svgImageObject.sprite = animationSprites[0];

        ToggleTimer(true);
        
        startingTime = 0;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            IterateSeconds();
        }

        Blink();
    }

    private void ToggleTimer(bool isRunning)
    {
        isTimerRunning = isRunning;
    }

    private void IterateSeconds()
    {
        startingTime += Time.deltaTime;
    }

    private void Blink()
    {
        if (svgImageObject.sprite == animationSprites[0])
        {
            if (startingTime >= secondsBetweenBlinks)
            {
                svgImageObject.sprite = animationSprites[1];

                startingTime = 0;
            }
        }
        else if(svgImageObject.sprite == animationSprites[1])
        {
            if (startingTime >= secondsToOpenEyes)
            {
                svgImageObject.sprite = animationSprites[0];

                startingTime = 0;
            }    
        }
    }
}
