using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 0.125f,leftMin,rightMax,upMax,downMin;
    private Vector3 initializedPosition, offset = new Vector3(0f,1f,-10f),downOffset,upOffset,smoothedPosition;
    private void Awake()
    {
        initializedPosition.x = target.position.x;
        initializedPosition.y = target.position.y+1;
        initializedPosition.z = -10;
        GetComponent<Transform>().position = initializedPosition;
    }
    private void LateUpdate()
    {
        smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        smoothedPosition.x = Mathf.Min(rightMax, Mathf.Max(smoothedPosition.x, leftMin));
        smoothedPosition.y = Mathf.Min(upMax, Mathf.Max(smoothedPosition.y, downMin));
        transform.position = smoothedPosition;
        if (Time.timeScale == 1f &&(PlayerMovement.canMove||!PlayerMovement.canView)&&PlayerMovement.canJump&& (Input.GetAxisRaw("Vertical")<0||Input.GetAxisRaw("View")<0))
        {
            if (CharacterController2D.m_FacingRight)
            {
                downOffset = new Vector3(4f, -5f, 0f);
            }
            else
            {
                downOffset = new Vector3(-4f, -5f, 0f);
            }
            smoothedPosition = Vector3.Lerp(transform.position, transform.position + downOffset, smoothSpeed * 0.5f);
            smoothedPosition.x = Mathf.Min(rightMax, Mathf.Max(smoothedPosition.x, leftMin));
            smoothedPosition.y = Mathf.Min(upMax, Mathf.Max(smoothedPosition.y, downMin));
            transform.position = smoothedPosition;
            if (PlayerMovement.canMove)
            {
                PlayerMovement.canMove = false;
                PlayerMovement.canView = false;
                target.GetComponent<Animator>().SetBool("ViewDown", true);
            }
        }
        else if (Time.timeScale == 1f && (PlayerMovement.canMove || !PlayerMovement.canView) && PlayerMovement.canJump && (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("View") > 0))
        {
            if (CharacterController2D.m_FacingRight)
            {
                upOffset = new Vector3(4f, 2.5f, 0f);
            }
            else
            {
                upOffset = new Vector3(-4f,2.5f, 0f);
            }
            smoothedPosition = Vector3.Lerp(transform.position, transform.position + upOffset, smoothSpeed * 0.5f);
            smoothedPosition.x = Mathf.Min(rightMax, Mathf.Max(smoothedPosition.x, leftMin));
            smoothedPosition.y = Mathf.Min(upMax, Mathf.Max(smoothedPosition.y, downMin));
            transform.position = smoothedPosition;
            if (PlayerMovement.canMove)
            {
                PlayerMovement.canMove = false;
                PlayerMovement.canView = false;
                target.GetComponent<Animator>().SetBool("ViewUp", true);
            }
        }
        if (!PlayerMovement.canView)
        {
            switch (FindObjectOfType<InputManager>().GetInputState())
            {
                case InputManager.EInputState.MouseKeyBoard:
                    if (Input.GetAxisRaw("Vertical") ==0)
                    {
                        PlayerMovement.canMove = true;
                        PlayerMovement.canView = true;
                        target.GetComponent<Animator>().SetBool("ViewDown", false);
                        target.GetComponent<Animator>().SetBool("ViewUp", false);
                    }
                    break;
                case InputManager.EInputState.Controller:
                    if (Input.GetAxisRaw("View") == 0)
                    {
                        PlayerMovement.canMove = true;
                        PlayerMovement.canView = true;
                        target.GetComponent<Animator>().SetBool("ViewDown", false);
                        target.GetComponent<Animator>().SetBool("ViewUp", false);
                    }
                    break;
            }
        }
    }
    public IEnumerator Shake(float duration,float magnitude)
    {
        Vector3 originalPos = transform.position;

        float elapsed = 0.0f;

        while (elapsed < duration && Time.timeScale == 1f)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(originalPos.x+x,originalPos.y+y,originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
    }
    
}
