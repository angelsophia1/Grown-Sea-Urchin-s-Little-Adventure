using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwitchDoor : MonoBehaviour {
    public GameObject doorClosed, doorOpen, timelineToUnactive;
    public void OpenOver()
    {
        PlayerMovement.canMove = true;
        doorOpen.SetActive(true);
        doorClosed.SetActive(false);
        timelineToUnactive.SetActive(false);
    }
}
