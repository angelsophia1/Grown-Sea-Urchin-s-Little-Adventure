using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ViewDownIntro : MonoBehaviour
{
    public GameObject textToDisplay, textToDisactive;
    private TextMeshProUGUI tMPText;
    private string key;
    private void Start()
    {
        tMPText = textToDisplay.GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.GetInt("AbilityIntroDisplayed", 0) >= 3)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(WaitToDisappear());
            PlayerPrefs.SetInt("AbilityIntroDisplayed", 3);
            FindObjectOfType<PausedMenu>().SaveFile(MainMenu.fileNumber);
        }
    }
    IEnumerator WaitToDisappear()
    {
        textToDisactive.SetActive(false);
        textToDisplay.SetActive(true);
        yield return null;
        switch (FindObjectOfType<InputManager>().GetInputState())
        {
            case InputManager.EInputState.MouseKeyBoard:
                key = "MOVEINTRO3";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
            case InputManager.EInputState.Controller:
                key = "MOVEINTROCONTROLLER3";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
        }
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
