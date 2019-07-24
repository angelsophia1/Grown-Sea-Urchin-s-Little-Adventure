using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelButton : MonoBehaviour {
    public Sprite mapButtonClear, mapButtonEnabled,mapButtonHiddenClear,mapButtonHiddenEnabled;
    public GameObject[] levelButton = new GameObject[10];
    public static bool[] enableClick= new bool[10];
    public GameObject challengeChanceMinus, map;
    public Text[] numbers;
    private Color whiteOpaque = new Color(1f,1f,1f,1f);
	// Use this for initialization
	void Start () {
        for (int i=0;i<=levelButton.Length-1;i++)
        {
            if (PlayerPrefs.GetInt("LevelCleared", 0) >= i + 1)
            {
                levelButton[i].GetComponent<Image>().sprite = mapButtonClear;
                levelButton[i].GetComponent<Image>().color = whiteOpaque;
                enableClick[i] = true;
            }
            else if (PlayerPrefs.GetInt("LevelCleared", 0) >= i)
            {
                levelButton[i].GetComponent<Image>().sprite = mapButtonEnabled;
                levelButton[i].GetComponent<Image>().color = whiteOpaque;
                enableClick[i] = true;
            }
            else
            {
                enableClick[i] = false;
            }
        }
        if (PlayerPrefs.GetInt("LevelCleared", 0) >= 7)
        {
            levelButton[6].GetComponent<Image>().sprite = mapButtonHiddenClear;
            levelButton[6].GetComponent<Image>().color = whiteOpaque;
        }
        else if (PlayerPrefs.GetInt("LevelCleared", 0) >= 6)
        {
            levelButton[6].GetComponent<Image>().sprite = mapButtonHiddenEnabled;
            levelButton[6].GetComponent<Image>().color = whiteOpaque;
            enableClick[6] = true;
        }
        else
        {
            enableClick[6] = false;
        }
    }
    private void OnEnable()
    {
        levelButton[0].GetComponent<Button>().onClick.AddListener(() => LevelButtonClick(0, "Level 1-1"));
        levelButton[1].GetComponent<Button>().onClick.AddListener(() => LevelButtonClick(1, "Level 1-2"));
        levelButton[2].GetComponent<Button>().onClick.AddListener(() => LevelButtonClick(2, "Level 1-3"));
        levelButton[3].GetComponent<Button>().onClick.AddListener(() => LevelButtonClick(3, "Level 2-1"));
        //levelButton[4].GetComponent<Button>().onClick.AddListener(() =>LevelButtonClick(4, "Level 2-2"));
        //levelButton[5].GetComponent<Button>().onClick.AddListener(() =>LevelButtonClick(5, "Level 2-3"));
        //levelButton[6].GetComponent<Button>().onClick.AddListener(() =>LevelButtonClick(6, "Level Hidden"));
        //levelButton[7].GetComponent<Button>().onClick.AddListener(() =>LevelButtonClick(7, "Level 3-1"));
        //levelButton[8].GetComponent<Button>().onClick.AddListener(() =>LevelButtonClick(8, "Level 3-2"));
        //levelButton[9].GetComponent<Button>().onClick.AddListener(() =>LevelButtonClick(9, "Level 3-3"));
    }
    public void LevelButtonClick(int ButtonNumber, string sceneName)
    {
        if (enableClick[ButtonNumber])
        {
            PlayerPrefs.SetInt("TrialChanceLeft", PlayerPrefs.GetInt("TrialChanceLeft", 3) - 1);
            FindObjectOfType<MapCanvas>().SaveFile(MainMenu.fileNumber);
            //numbers[0].text = (PlayerPrefs.GetInt("TrialChanceLeft", 3)+1).ToString();
            //numbers[1].text = PlayerPrefs.GetInt("TrialChanceLeft", 3).ToString();
            map.SetActive(false);
            challengeChanceMinus.SetActive(true);
            FindObjectOfType<ChallengeChanceMinus>().GetData(sceneName);
            Time.timeScale = 1f;
        }
    }

}
