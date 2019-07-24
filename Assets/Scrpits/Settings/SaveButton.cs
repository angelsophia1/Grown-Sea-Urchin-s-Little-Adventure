using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour {
    public GameObject[] fileMark;
    public void SaveButtonClicked()
    {
        DisplayFileMark(MainMenu.fileNumber);
        FindObjectOfType<MapMenuEventSystem>().SelectFirst(4);
    }
     void DisplayFileMark(int fN)
    {
        switch (fN)
        {
            case 1:
                fileMark[0].SetActive(true);
                fileMark[1].SetActive(false);
                break;
            case 2:
                fileMark[0].SetActive(false);
                fileMark[1].SetActive(true);
                break;
            default:
                Debug.Log("No file number.");
                break;
        }
    }
}
