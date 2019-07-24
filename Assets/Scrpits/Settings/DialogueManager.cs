using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public LocalizationUIText text;
    public TextMeshProUGUI tmpText;
    public GameObject initialIntro, dialogue, mapPanel;
    private int i ;
    private string key;
    private string sentence;
    public void Start()
    {
        if (PlayerPrefs.GetInt("NewBeginning",0) == 0)
        {
            i = 1;
        }
        else
        {
            if (PlayerPrefs.GetInt("NewBeginning", 0) == 1)
            {
                i = 7;
            }
        }

        if (i == 1)
        {
            key = "CONTENT11";
            sentence = LocalizationManager.Instance.GetText(key);
            StartCoroutine(DisplayWordByWord(sentence));
        }
    }
    public void ContinueButton()
    {

        if ( i <6 )
        {
            i++;
            key = "CONTENT1" + i;
            text.key = key;
            sentence = LocalizationManager.Instance.GetText(key);
            StopAllCoroutines();
            StartCoroutine(DisplayWordByWord(sentence));
        }
        if(i>=6)
        {
            if (i == 6)
            {
                i++;
            }else
            {
                PlayerPrefs.SetInt("CutScene1", i);
                PlayerPrefs.SetInt("NewBeginning", 1);
                FindObjectOfType<MapCanvas>().SaveFile(MainMenu.fileNumber);
                initialIntro.SetActive(true);
                FindObjectOfType<MapMenuEventSystem>().SelectFirst(5);
                mapPanel.SetActive(true);
                dialogue.SetActive(false);
            }
        }


    }
    IEnumerator DisplayWordByWord(string sentence)
    {
        yield return null;
        tmpText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            tmpText.text += letter;
            yield return null;
        }
    }
}
