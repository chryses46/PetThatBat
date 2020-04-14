using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<UIController>().TriggerTransitioner(false);
    }

    private void OnDisable()
    {
        FindObjectOfType<UIController>().TriggerTransitioner(true);
    }
}
