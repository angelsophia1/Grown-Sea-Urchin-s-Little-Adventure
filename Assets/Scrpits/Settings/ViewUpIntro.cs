using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ViewUpIntro : MonoBehaviour
{
    public GameObject textToDisplay, textToDisactive, moveIntroCanvas, introTriggers;
    private TextMeshProUGUI tMPText;
    private string key;
    private void Start()
    {
        tMPText = textToDisplay.GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.GetInt("AbilityIntroDisplayed", 0) >= 4)
        {
            introTriggers.SetActive(false);
            moveIntroCanvas.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(WaitToDisappear());
            PlayerPrefs.SetInt("AbilityIntroDisplayed",4);
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
                key = "MOVEINTRO4";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
            case InputManager.EInputState.Controller:
                key = "MOVEINTROCONTROLLER4";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
        }
        yield return new WaitForSeconds(2f);
        moveIntroCanvas.SetActive(false);
        introTriggers.SetActive(false);
        gameObject.SetActive(false);
    }
}
