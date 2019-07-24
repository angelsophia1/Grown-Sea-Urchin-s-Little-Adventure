using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrialChanceLeft : MonoBehaviour {
    public TextMeshProUGUI coinsCollectedText;
    private int trialChanceLeft,coinsCollected;
    // Use this for initialization
    void Start()
    {
        coinsCollected = PlayerPrefs.GetInt("CoinsCollected", 0);
        if (coinsCollected >= 10)
        {

            int j = (int)Mathf.Floor(((float)coinsCollected) / 10);
            for (int i = 1; i <= j; i++)
            {
                PlayerPrefs.SetInt("TrialChanceLeft", PlayerPrefs.GetInt("TrialChanceLeft", 3) + 1);
                PlayerPrefs.SetInt("CoinsCollected", coinsCollected - 10);
            }
            FindObjectOfType<MapCanvas>().SaveFile(MainMenu.fileNumber);
        }
        trialChanceLeft = PlayerPrefs.GetInt("TrialChanceLeft", 3);
        coinsCollected = PlayerPrefs.GetInt("CoinsCollected", 0);
        GetComponent<TextMeshProUGUI>().text = trialChanceLeft.ToString();
        coinsCollectedText.text = coinsCollected.ToString();
    }
    //void Start()
    //{
    //    trialChanceLeft = PlayerPrefs.GetInt("TrialChanceLeft", 3);
    //    GetComponent<TextMeshProUGUI>().text = trialChanceLeft.ToString();
    //}
}
