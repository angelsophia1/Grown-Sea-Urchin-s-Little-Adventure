using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;
public class MainMenu : MonoBehaviour {
    public static int fileNumber;
    public GameObject[] fileMark1;
    public GameObject[] fileMark2;
    public Animator sceneMainMenu;
    private void Start()
    {
        //0 is for the first selection case, to not show file mark(instead this will create a useless file player0)
        fileNumber = PlayerPrefs.GetInt("FileNumber",0);
        DisplayFileMark(fileNumber);
    }
    public void PlayButton(int fN)
    {
        int i = PlayerPrefs.GetInt("CurrentLanguageID", 0);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("CurrentLanguageID",i);
        PlayerPrefs.SetInt("FileNumber",fN);
        fileNumber = fN;
        SaveFile();
        sceneMainMenu.SetTrigger("FadeOut");
    }
    public void LoadButton(int fN)
    {
        if (File.Exists(Application.persistentDataPath + "/Player"+fN+".json"))
        {
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/Player" + fN + ".json");
            JsonData itemData = JsonMapper.ToObject(jsonString);
            fileNumber = (int)itemData["fileNumber"];
            int newBeginning = (int)itemData["newBeginning"];
            int abilityIntroDisplayed = (int)itemData["abilityIntroDisplayed"];
            int cutScene1 = (int)itemData["cutScene1"];
            int cutScene2 = (int)itemData["cutScene2"];
            int coinsCollected = (int)itemData["coinsCollected"];
            int trialChanceLeft = (int)itemData["trialChanceLeft"];
            int levelCleared = (int)itemData["levelCleared"];
            PlayerPrefs.SetInt("FileNumber",fileNumber);
            PlayerPrefs.SetInt("NewBeginning", newBeginning);
            PlayerPrefs.SetInt("AbilityIntroDisplayed",abilityIntroDisplayed);
            PlayerPrefs.SetInt("CutScene1", cutScene1);
            PlayerPrefs.SetInt("CutScene2", cutScene2);
            PlayerPrefs.SetInt("CoinsCollected", coinsCollected);
            PlayerPrefs.SetInt("TrialChanceLeft", trialChanceLeft);
            PlayerPrefs.SetInt("LevelCleared", levelCleared);
            sceneMainMenu.SetTrigger("FadeOut");
        }
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    void DisplayFileMark(int fN)
    {
        switch (fN)
        {
            case 1:
                fileMark1[0].SetActive(true);
                fileMark1[1].SetActive(true);
                break;
            case 2:
                fileMark2[0].SetActive(true);
                fileMark2[1].SetActive(true);
                break;
            default:
                Debug.Log("No fileNumber got from Awake.");
                break;
        }
    }
    public void SaveFile()
    {
        //Character player = new Character(fileNumber,PlayerPrefs.GetInt("NewBeginning", 0),PlayerPrefs.GetInt("AbilityIntroDisplayed",0), PlayerPrefs.GetInt("CutScene1",1),PlayerPrefs.GetInt("CutScene2", 1), PlayerPrefs.GetInt("CoinsCollected", 0), PlayerPrefs.GetInt("TrialChanceLeft", 3), PlayerPrefs.GetInt("LevelCleared", 0));
        Character player = new Character(fileNumber);
        JsonData playerJson = JsonMapper.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + "/Player" + fileNumber + ".json", playerJson.ToString());
    }
}
