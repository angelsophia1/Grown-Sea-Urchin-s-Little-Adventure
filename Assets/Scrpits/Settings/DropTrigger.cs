using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrigger : MonoBehaviour {
    public Rigidbody2D dropTriangle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            dropTriangle.gravityScale = 1f;
            Destroy(gameObject);
        }
    }
}
