using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;
public class MapCanvas : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenu, mapMenu,framForEsc;
    private Animator sceneMap;
    private void Start()
    {
        sceneMap = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)||Input.GetButtonDown("Pause"))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        mapMenu.SetActive(true);
        framForEsc.SetActive(false);
        FindObjectOfType<MapMenuEventSystem>().SelectFirst(2);
    }
    public void SaveFile(int fileNumber)
    {
        if (MainMenu.fileNumber != fileNumber)
        {
            MainMenu.fileNumber = fileNumber;
            PlayerPrefs.SetInt("FileNumber", fileNumber);
        }
        //Character player = new Character(fileNumber, PlayerPrefs.GetInt("NewBeginning", 0), PlayerPrefs.GetInt("AbilityIntroDisplayed", 0), PlayerPrefs.GetInt("CutScene1", 1), PlayerPrefs.GetInt("CutScene2", 1), PlayerPrefs.GetInt("CoinsCollected", 0), PlayerPrefs.GetInt("TrialChanceLeft", 3), PlayerPrefs.GetInt("LevelCleared", 0));
        Character player = new Character(fileNumber);
        JsonData playerJson = JsonMapper.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + "/Player" + fileNumber + ".json", playerJson.ToString());
        FindObjectOfType<MapMenuEventSystem>().SelectFirst(3);
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
        mapMenu.SetActive(false);
        FindObjectOfType<MapMenuEventSystem>().SelectFirst(3);
    }
    public void MainButton()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        sceneMap.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu");
    }
}
