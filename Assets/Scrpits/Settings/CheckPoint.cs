using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    public int pointNumber;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag( "Player")&& GameManager.checkPointIndex <pointNumber)
        {
            GameManager.checkPointIndex++;
        }
    }
}
