using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreColumn : MonoBehaviour
{
    [SerializeField] float animationStartDelay;

    [SerializeField] Text score;
    [SerializeField] SVGImage playerPortrait;

    bool animationComplete;

    public void InitializeColumn(int score, Sprite playerPortrait)
    {
        this.score.text = score.ToString();

        this.playerPortrait.sprite = playerPortrait;
    }

    public void AnimateColumn(float timeInSeconds)
    {
        if(timeInSeconds >= animationStartDelay)
        {
            GetComponent<Animator>().SetTrigger("beginTransition");
        }
    }

    public void SetAnimationComplete()
    {
        animationComplete = true;
    }

    public bool GetAnimationCompletionStatus()
    {
        return animationComplete;
    }
}
