using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AttackIntro : MonoBehaviour {
    public GameObject textToDisplay,iconToDisplay;
    private TextMeshProUGUI tMPText;
    private string key;
    // Use this for initialization
    void Start () {
        tMPText = textToDisplay.GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.GetInt("AbilityIntroDisplayed", 0) >= 5)
        {
            gameObject.SetActive(false);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(WaitToDisappear());
            iconToDisplay.SetActive(true);
            PlayerPrefs.SetInt("AbilityIntroDisplayed", 5);
            FindObjectOfType<PausedMenu>().SaveFile(MainMenu.fileNumber);
        }
    }
    IEnumerator WaitToDisappear()
    {
        textToDisplay.SetActive(true);
        yield return null;
        switch (FindObjectOfType<InputManager>().GetInputState())
        {
            case InputManager.EInputState.MouseKeyBoard:
                key = "MOVEINTRO5";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
            case InputManager.EInputState.Controller:
                key = "MOVEINTROCONTROLLER5";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
        }
        yield return new WaitForSeconds(2f);
        textToDisplay.SetActive(false);
        gameObject.SetActive(false);
    }
}
