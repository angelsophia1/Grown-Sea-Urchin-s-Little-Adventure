using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamera : MonoBehaviour {
    public Transform originalPos;
    public Transform finalPos;
    public Vector3 offset;
    private float smoothSpeed = 0.125f;
    private void Awake()
    {
        transform.position = originalPos.position + offset;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, finalPos.position + offset, smoothSpeed * 2f);
        transform.position = smoothedPosition;
    }
}
