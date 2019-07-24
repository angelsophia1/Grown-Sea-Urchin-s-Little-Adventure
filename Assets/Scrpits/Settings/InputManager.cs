using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour {
    public static InputManager Instance { get{ return instance; } }
    private static InputManager instance;
    private EInputState m_State;
    private Vector3 lastMouseCoordinate = Vector3.zero;

	// Use this for initialization
	void Awake () {
        m_State = EInputState.MouseKeyBoard;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (this != instance)
                Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;
        if (m_State == EInputState.Controller)
        //if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0 || m_State == EInputState.Controller)
        {
            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        //else if (mouseDelta.magnitude > 0 || m_State == EInputState.MouseKeyBoard)
        else if(m_State == EInputState.MouseKeyBoard)
        {
            if (mouseDelta.magnitude > 0)
            {
                if (!Cursor.visible)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }else if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0)
            {
                if (Cursor.visible)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }
        lastMouseCoordinate = Input.mousePosition;
    }
    //Mouse or Controller Check
    public enum EInputState
    {
        MouseKeyBoard,
        Controller
    }

    private void OnGUI()
    {
        switch (m_State)
        {
            case EInputState.MouseKeyBoard:
                if (IsControllerInput())
                {
                    m_State = EInputState.Controller;
                }
                break;
            case EInputState.Controller:
                if (IsMouseKeyBoard())
                {
                    m_State = EInputState.MouseKeyBoard;
                }
                break;
        }
    }
    //Public Member Methods
    public EInputState GetInputState()
    {
        return m_State;
    }
    private bool IsMouseKeyBoard()
    {
        if (Event.current.isKey || Event.current.isMouse)
        {
            return true;
        }
        if (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f)
        {
            return true;
        }
        return false;
    }
    private bool IsControllerInput()
    {
        if (Input.GetKey(KeyCode.Joystick1Button0) ||
            Input.GetKey(KeyCode.Joystick1Button1) ||
            Input.GetKey(KeyCode.Joystick1Button2) ||
            Input.GetKey(KeyCode.Joystick1Button3) ||
            Input.GetKey(KeyCode.Joystick1Button4) ||
            Input.GetKey(KeyCode.Joystick1Button5) ||
            Input.GetKey(KeyCode.Joystick1Button6) ||
            Input.GetKey(KeyCode.Joystick1Button7) ||
            Input.GetKey(KeyCode.Joystick1Button8) ||
            Input.GetKey(KeyCode.Joystick1Button9) ||
            Input.GetKey(KeyCode.Joystick1Button10) ||
            Input.GetKey(KeyCode.Joystick1Button11) ||
            Input.GetKey(KeyCode.Joystick1Button12) ||
            Input.GetKey(KeyCode.Joystick1Button13) ||
            Input.GetKey(KeyCode.Joystick1Button14) ||
            Input.GetKey(KeyCode.Joystick1Button15) ||
            Input.GetKey(KeyCode.Joystick1Button16) ||
            Input.GetKey(KeyCode.Joystick1Button17) ||
            Input.GetKey(KeyCode.Joystick1Button18) ||
            Input.GetKey(KeyCode.Joystick1Button19))
        {
            return true;
        }
        if (Input.GetAxis("XC Left Stick X") != 0.0f ||
            Input.GetAxis("XC Left Stick Y") != 0.0f ||
            //Input.GetAxis("XC Triggers") != 0.0f ||
            //Input.GetAxis("XC Right Stick X") != 0.0f ||
            Input.GetAxis("View") != 0.0f)
        {
            return true;
        }

        return false;
    }
}
