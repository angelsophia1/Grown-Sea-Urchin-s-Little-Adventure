using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonTrigger : MonoBehaviour {
    public GameObject interactionText, timelineToDisplay;
    public Animator door;
    public static bool buttonTrigger;
    private bool isOpen;
    private TextMeshProUGUI tMPText;
    private string key;
    private void Start()
    {
        tMPText = interactionText.GetComponent<TextMeshProUGUI>();
        isOpen = false;
        buttonTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag( "Player"))
        {
            StartCoroutine(WaitToAppear());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((Input.GetKeyDown(KeyCode.E)||Input.GetButtonDown("Interact"))&& !isOpen)
        {
            PlayerMovement.canMove = false;
            timelineToDisplay.SetActive(true);
            StartCoroutine(WaitBeforeOpen());
            isOpen = true;
            buttonTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag( "Player"))
        {
            interactionText.SetActive(false);
        }
    }

    IEnumerator WaitBeforeOpen()
    {
        yield return new WaitForSeconds(0.5f);
        door.SetBool("isOpen", true);
    }
    IEnumerator WaitToAppear()
    {
        interactionText.SetActive(true);
        yield return null;
        switch (FindObjectOfType<InputManager>().GetInputState())
        {
            case InputManager.EInputState.MouseKeyBoard:
                key = "INTERACTIONTEXT";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
            case InputManager.EInputState.Controller:
                key = "INTERACTIONCONTROLLERTEXT";
                tMPText.text = LocalizationManager.Instance.GetText(key);
                break;
        }
    }
}
