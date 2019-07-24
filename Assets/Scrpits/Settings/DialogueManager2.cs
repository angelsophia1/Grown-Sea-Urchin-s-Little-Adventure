using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager2 : MonoBehaviour {
    private string key;
    private string sentence;
    private int i;
    public LocalizationUIText text;
    public TextMeshProUGUI tmpText;
    public GameObject mapMenu, dialogue,mapPanel;
    public void Start()
    {
        i = 1;
        if (PlayerPrefs.GetInt("LevelCleared", 0) == 3 && PlayerPrefs.GetInt("CutScene2", 1) == 1)
        {
            key = "CONTENT21";
            sentence = LocalizationManager.Instance.GetText(key);
            StartCoroutine(DisplayWordByWord(sentence));

        }
    }

    public void ContinueButton()
    {
        if (i < 7)
        {
            i++;
            key = "CONTENT2" + i;
            text.key = key;
            sentence = LocalizationManager.Instance.GetText(key);
            StopAllCoroutines();
            StartCoroutine(DisplayWordByWord(sentence));

        }
        if (i >= 7)
        {
            if (i == 7)
            {
                i++;
            }
            else
            {
                PlayerPrefs.SetInt("CutScene2", i);
                FindObjectOfType<MapCanvas>().SaveFile(MainMenu.fileNumber);
                mapMenu.SetActive(true);
                FindObjectOfType<MapMenuEventSystem>().SelectFirst(2);
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
            yield return null ;
        }

    }
}
