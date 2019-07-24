using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {

    private float rotateSpeed = 360f;
    public float direction = -1f;
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime*direction); 
    }
    void LeftRotate()
    {
        direction = 1f;
    }
    void RightRotate()
    {
        direction = -1f;
    }
    
}
