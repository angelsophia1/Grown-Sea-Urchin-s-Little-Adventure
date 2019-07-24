using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    private Rigidbody2D rb;
    private float minTime = 2f, maxTime = 3f, moveTime, speed = 0.5f, moveSpeed;
    private int randomNum;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTime = Random.Range(minTime,maxTime);
        randomNum = Random.Range(0,2);
        switch (randomNum)
        {
            case 0:
                moveSpeed = speed;
                break;
            case 1:
                moveSpeed = -speed;
                break;
            default:
                moveSpeed = speed;
                break;
        }
    }
    // Update is called once per frame
    void Update () {
        if (moveTime>0f)
        {
            rb.velocity = new Vector3(1f,0f,0f) * moveSpeed;
            moveTime -= Time.deltaTime;
        }
        else
        {
            moveTime = Random.Range(minTime, maxTime);
            moveSpeed *=-1f;
        }
	}
}
