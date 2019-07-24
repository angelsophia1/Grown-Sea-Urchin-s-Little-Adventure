using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;
public class PausedMenu : MonoBehaviour {
    public GameObject pauseMenu;
    private Animator anim;
    private bool isGamePaused = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
        {
            PauseButtonClicked();
        }

    }
    public void PauseButtonClicked()
    {
        if (isGamePaused)
        {
            StartCoroutine(WaitToResume());
        }
        else
        {
            StartCoroutine(WaitToPause());
        }
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
    }
    public void MapButton()
    {
        StartCoroutine(LoadScene("Map"));
    }

    public void MainButton()
    {
        StartCoroutine(LoadScene("Main Menu"));
    }
    IEnumerator LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator WaitToPause()
    {
        anim.SetBool("Appear", true);
        PlayerMovement.canMove = false;
        yield return new WaitForSeconds(0.25f);
        pauseMenu.SetActive(true);
        FindObjectOfType<InGameEventSystem>().SelectFirst(0);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    IEnumerator WaitToResume()
    {
        anim.SetBool("Appear", false);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.25f);
        pauseMenu.SetActive(false);
        isGamePaused = false;
        PlayerMovement.canMove = true;
    }
}
