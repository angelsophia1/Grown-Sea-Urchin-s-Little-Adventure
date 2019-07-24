using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveIntro : MonoBehaviour {
    public GameObject textToDisplay;
    private TextMeshProUGUI tMPText;
    private string key;
	// Use this for initialization
	void Start () {
        tMPText = textToDisplay.GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.GetInt("AbilityIntroDisplayed", 0) < 1)
        {
            StartCoroutine(WaitToDisappear());
            PlayerPrefs.SetInt("AbilityIntroDisplayed", 1);
            FindObjectOfType<PausedMenu>().SaveFile(MainMenu.fileNumber);
        } else if (PlayerPrefs.GetInt("AbilityIntroDisplayed", 0) >= 2)
        {
            gameObject.SetActive(false);
        }
	}
	IEnumerator WaitToDisappear()
    {
        textToDisplay.SetActive(true);
        yield return null;
        switch (FindObjectOfType<InputManager>().GetInputState())
        {
            case InputManager.EInputState.MouseKeyBoard:
                key = "MOVEINTRO1";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
            case InputManager.EInputState.Controller:
                key = "MOVEINTROCONTROLLER1";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
        }
        yield return new WaitForSeconds(2f);
        textToDisplay.SetActive(false);
        //dont set active to false, for the jump intro not yet displayed.
    }
}
