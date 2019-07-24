using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InitialIntro : MonoBehaviour {
    public GameObject mapMenu;
    public GameObject[] thingsToDisplay;
    public TextMeshProUGUI[] texts;
    private void Start()
    {
        StartCoroutine(DisplayThenWait(4));
    }
    public void DisplayOver()
    {
        gameObject.SetActive(false);
        mapMenu.SetActive(true);
        FindObjectOfType<MapMenuEventSystem>().SelectFirst(2);
    }
    IEnumerator DisplayThenWait(int indexNumber)
    {
        for (int i = 0; i <= indexNumber; i++)
        {
            thingsToDisplay[i].SetActive(true);
            int j = i + 1;
            string key = "INITIALINTROTEXT" + j;
            string sentence = LocalizationManager.Instance.GetText(key);
            yield return null;
            texts[i].text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                texts[i].text += letter;
                yield return null;
            }
        }
    }
}
