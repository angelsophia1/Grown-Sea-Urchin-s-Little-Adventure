using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapManager : MonoBehaviour {
    public GameObject mapMenu, trialOver, cutScene1, cutScene2, mapPanel;
    private void Start()
    {
        Time.timeScale = 1f;
        //original start now awake for MapMenuEventSystem. But this could trigger one condition, if player didn't save his file and quit the game , then when TrialChanceLeft == 0, although there were enough coin to gain a chance,
        //still the file will welcome a TrialOver at the next opening.
        if (PlayerPrefs.GetInt("TrialChanceLeft", 3) >= 1)
        {
            if (PlayerPrefs.GetInt("CutScene1", 1) == 1)
            {
                cutScene1.SetActive(true);
                mapPanel.SetActive(false);
                //mapMenu.SetActive(false);
            }
            if (PlayerPrefs.GetInt("CutScene1", 1) >= 7 && PlayerPrefs.GetInt("LevelCleared", 0) < 3)
            {
                mapMenu.SetActive(true);
                mapPanel.SetActive(true);
            }
            if (PlayerPrefs.GetInt("LevelCleared", 0) == 3 && PlayerPrefs.GetInt("CutScene2", 1) < 8)
            {
                cutScene2.SetActive(true);
                mapPanel.SetActive(false);
                //mapMenu.SetActive(false);
            }
            if (PlayerPrefs.GetInt("LevelCleared", 0) >= 3 && PlayerPrefs.GetInt("LevelCleared", 0) < 6 && PlayerPrefs.GetInt("CutScene2", 1) >= 8)
            {
                mapMenu.SetActive(true);
                mapPanel.SetActive(true);
            }
        }
        else
        {
            trialOver.SetActive(true);
            //mapMenu.SetActive(false);
        }
    }
}


