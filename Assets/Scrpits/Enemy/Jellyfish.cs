using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : EnemyGeneral {
    private bool movingUp = true;
    private float moveTime = 2f;
    private float moveSpeed = 0.1f;
    //private void Awake()
    //{
    //    enemyHealth = 2;
    //}
    // Update is called once per frame
    void Update () {
        if (movingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed ,Space.World);
            moveTime -= Time.deltaTime;
        }
        else
        {
            transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed, Space.World);
            moveTime -= Time.deltaTime;
        }
        if (moveTime<0.01f)
        {
            moveTime = 2f;
            movingUp = !movingUp;
        }
	}
}
