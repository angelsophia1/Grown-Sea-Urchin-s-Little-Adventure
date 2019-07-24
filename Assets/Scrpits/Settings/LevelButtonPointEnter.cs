using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonPointEnter : MonoBehaviour {
    public GameObject frameToDisplay;

    public void DisplayFrame()
    {
        frameToDisplay.transform.position = transform.position;
        frameToDisplay.SetActive(true);
    }
    public void HideFrame()
    {
        frameToDisplay.SetActive(false);
    }
}
