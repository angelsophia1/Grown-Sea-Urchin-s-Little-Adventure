using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelPassMenu : MonoBehaviour {
    public GameObject[] thingsToDisplay;
    public GameObject passMenu;
    public TextMeshProUGUI[] mainTexts;
    public Text[] numberTexts;
    private float displayTime;
    private bool displayFlag;
    private int trialChanceLeftCal, coinsCollectedCal;
    private void Start()
    {
        displayTime = 5f;
        displayFlag = false;
        thingsToDisplay[0].SetActive(true);
        //numberTexts[0].text = PlayerPrefs.GetInt("CoinsCollected",0).ToString();
        numberTexts[0].text =( PlayerPrefs.GetInt("CoinsCollected", 0) - GameManager.itemsCollected).ToString();
        //numberTexts[1].text = (PlayerPrefs.GetInt("CoinsCollected", 0) + GameManager.itemsCollected).ToString();
        numberTexts[1].text = PlayerPrefs.GetInt("CoinsCollected", 0) .ToString();
        numberTexts[2].text = PlayerPrefs.GetInt("TrialChanceLeft",3).ToString();
        numberTexts[3].text = PlayerPrefs.GetInt("TrialChanceLeft",3).ToString();
        trialChanceLeftCal = PlayerPrefs.GetInt("TrialChanceLeft", 3);
        //coinsCollectedCal = PlayerPrefs.GetInt("CoinsCollected", 0) + GameManager.itemsCollected;
        coinsCollectedCal = PlayerPrefs.GetInt("CoinsCollected", 0);
        if (coinsCollectedCal >= 10)
        {
            int j = (int)Mathf.Floor(((float)coinsCollectedCal )/ 10);
            for (int i = 1; i <= j; i++)
            {
                trialChanceLeftCal +=1;
                coinsCollectedCal-=10;
            }
            numberTexts[3].text = trialChanceLeftCal.ToString();
            numberTexts[4].text = coinsCollectedCal.ToString();
            displayFlag = true;
        }
        if(displayFlag)
        {
            StartCoroutine(DisplayThenWait(7));
            StartCoroutine(DisplayFlagTrue());
        }
        else
        {
            StartCoroutine(DisplayThenWait(7));
        }
    }
    private void Update()
    {
        if (displayTime<0.01f)
        {
            PlayerPrefs.SetInt("TrialChanceLeft",trialChanceLeftCal);
            PlayerPrefs.SetInt("CoinsCollected",coinsCollectedCal);
            FindObjectOfType<PausedMenu>().SaveFile(MainMenu.fileNumber);
            passMenu.SetActive(true);
            FindObjectOfType<InGameEventSystem>().SelectFirst(3);
            gameObject.SetActive(false);
        }
        else
        {
            displayTime -= Time.deltaTime;
        }
    }
    IEnumerator DisplayWordByWord(TextMeshProUGUI tmpText,string key)
    {
        string sentence = LocalizationManager.Instance.GetText(key);
        yield return null;
        tmpText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            tmpText.text += letter;
            yield return null;
        }
    }
    IEnumerator DisplayThenWait(int indexNumber)
    {
        for (int i =0;i<=indexNumber;i++)
        {
            thingsToDisplay[i].SetActive(true);
            switch (i)
            {
                case 0:
                    StartCoroutine(DisplayWordByWord(mainTexts[0],"COINSCOLLECTED"));
                    break;
                case 4:
                    StartCoroutine(DisplayWordByWord(mainTexts[1],"CHALLENGECHANCELEFT"));
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.4f);
        }
    }
    IEnumerator DisplayFlagTrue()
    {
        yield return new WaitForSeconds(2.4f);
        thingsToDisplay[8].SetActive(true);
        yield return new WaitForSeconds(0.4f);
        thingsToDisplay[9].SetActive(true);
    }
}
