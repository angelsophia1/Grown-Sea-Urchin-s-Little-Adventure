using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float moveSpeed;
    public Transform[] points;
    public int pointSelection = 1;



    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,points[pointSelection].position,moveSpeed*Time.deltaTime);
        if (transform.position ==points[pointSelection].position)
        {
            pointSelection++;
            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }
        }
    }
}
