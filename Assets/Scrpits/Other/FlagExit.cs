using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FlagExit : MonoBehaviour {
    public int levelNumber;
    public GameObject levelPassMenu;
    private bool levelOver;
    private void Start()
    {
        levelOver = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int levelNumberMinus = levelNumber - 1;
        if (collision.transform.CompareTag("Player") && !levelOver)
        {
            if (PlayerPrefs.GetInt("LevelCleared", levelNumberMinus) <= levelNumber)
            {
                PlayerPrefs.SetInt("LevelCleared", levelNumber);
            }
            PlayerPrefs.SetInt("CoinsCollected", PlayerPrefs.GetInt("CoinsCollected", 0) + GameManager.itemsCollected);
            FindObjectOfType<PausedMenu>().SaveFile(MainMenu.fileNumber);
            levelOver = true;
            StartCoroutine(WaitThenDisplay());
        }
    }
    IEnumerator WaitThenDisplay()
    {
        yield return new WaitForSeconds(0.5f);
        levelPassMenu.SetActive(true);
    }
    public bool GetLevelOver()
    {
        return levelOver;
    }
}
