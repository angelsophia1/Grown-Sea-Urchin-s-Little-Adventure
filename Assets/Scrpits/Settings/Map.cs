using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public GameObject explanationCoin, explanationTrial, frameForMarkCoin, frameForMarkTrial;
    private bool isExCoinOn = false;
    private bool isExTrialOn = false;

    public void ExplanationCoin()
    {
        if (!isExTrialOn)
        {
            explanationCoin.SetActive(true);
            isExCoinOn = true;
            StartCoroutine(WaitSetUnactive(explanationCoin,frameForMarkCoin, isExCoinOn));
        }
        else
        {
            explanationTrial.SetActive(false);
            isExTrialOn = false;
            explanationCoin.SetActive(true);
            isExCoinOn = true;
            StartCoroutine(WaitSetUnactive(explanationCoin,frameForMarkCoin, isExCoinOn));
        }

    }
    public void ExplanationTrial()
    {
        if (!isExCoinOn)
        {
            explanationTrial.SetActive(true);
            isExTrialOn = true;
            StartCoroutine(WaitSetUnactive(explanationTrial,frameForMarkTrial, isExTrialOn));
        }
        else
        {
            explanationCoin.SetActive(false);
            isExCoinOn = false;
            explanationTrial.SetActive(true);
            isExTrialOn = true;
            StartCoroutine(WaitSetUnactive(explanationTrial,frameForMarkTrial, isExTrialOn));
        }
    }
    public void Close(GameObject toClose)
    {
        toClose.SetActive(false);

    }
    IEnumerator WaitSetUnactive(GameObject toUnactive,GameObject frameToUnactive, bool isOn)
    {
        yield return new WaitForSeconds(3f);
        toUnactive.SetActive(false);
        if (frameToUnactive.activeSelf)
        {
            frameToUnactive.SetActive(false);
            FindObjectOfType<MapMenuEventSystem>().SelectFirst(2);
        }
        isOn = false;
    }
}
