using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {

    public void ChineseButton()
    {
        GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>().currentLanguageID = 1;
        SceneManager.LoadScene("Main Menu");
        PlayerPrefs.SetInt("CurrentLanguageID",1);
        PlayerPrefs.Save();

    }
    public void EnglishButton()
    {
        GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>().currentLanguageID = 0;
        SceneManager.LoadScene("Main Menu");
        PlayerPrefs.SetInt("CurrentLanguageID", 0);
        PlayerPrefs.Save();
    }
}
