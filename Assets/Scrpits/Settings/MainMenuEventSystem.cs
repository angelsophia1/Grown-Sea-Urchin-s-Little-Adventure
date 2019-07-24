using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MainMenuEventSystem : MonoBehaviour {
    public GameObject[] firstToSelect = new GameObject[4], menuActive = new GameObject[4];
    private EventSystem eventSystem;
    private bool needFirst;
	// Use this for initialization
	void Start () {
        eventSystem = GetComponent<EventSystem>();
        needFirst = true;
	}
    private void Update()
    {
        if (Cursor.visible)
        {
            eventSystem.SetSelectedGameObject(null);
            needFirst = true;
        }

        if (!Cursor.visible && needFirst)
        {
            for (int i = 0;i < 4;i++)
            {
                if (menuActive[i].activeSelf)
                {
                    eventSystem.SetSelectedGameObject(null);
                    SelectFirst(i);
                }
            }

            needFirst = false;
        }
    }
    public void SelectFirst(int i)
    {
        if (firstToSelect[i] != null)
        {
            eventSystem.SetSelectedGameObject(firstToSelect[i]);
        }
    }
}
