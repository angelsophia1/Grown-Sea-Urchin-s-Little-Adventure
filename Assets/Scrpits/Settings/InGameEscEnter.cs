using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameEscEnter : MonoBehaviour
{
    public GameObject frameToDisplay;

    public void DisplayFrame()
    {
        frameToDisplay.SetActive(true);
    }
    public void HideFrame()
    {
        frameToDisplay.SetActive(false);
    }
}
