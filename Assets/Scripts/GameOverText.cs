using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("scaleUp");
    }

    public void  NextAction()
    {
        FindObjectOfType<GameOver>().PopulatePlayerTotalScores();

        gameObject.SetActive(false);
    }
}
