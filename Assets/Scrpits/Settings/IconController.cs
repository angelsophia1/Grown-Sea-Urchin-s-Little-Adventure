using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconController : MonoBehaviour {
    public Image iconPowering;
    public Image iconNumber;
    public Sprite[] iconNumberSprites;
	// Use this for initialization
	void Start () {
        //if attack ability not acquired,then do not display.
        if (PlayerPrefs.GetInt("AbilityIntroDisplayed",0)<5)
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        switch (AttackController.attackCount)
        {
            case 0:
                iconNumber.sprite = iconNumberSprites[0];
                break;
            case 1:
                iconNumber.sprite = iconNumberSprites[1];
                break;
            case 2:
                iconNumber.sprite = iconNumberSprites[2];
                break;
            case 3:
                iconNumber.sprite = iconNumberSprites[3];
                break;
            default:
                Debug.Log("No attack count for icon number.");
                break;

        }
	}
    private void FixedUpdate()
    {
        iconPowering.fillAmount =1- AttackController.attackPoweringTime / 2f;
    }
}
