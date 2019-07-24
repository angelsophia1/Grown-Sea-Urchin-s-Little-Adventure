using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderTheSea : MonoBehaviour {
    private Rigidbody2D targetRb;
    private bool targetDown ;
    private float lessSpeed = 1.25f,maxYSpeed = -1f;
    private Vector2 maxVelocity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag ("Player"))
        {
            targetRb = collision.GetComponent<Rigidbody2D>();
            targetRb.velocity = new Vector2(0f,0f);
            targetDown = true;
            StartCoroutine(waitRespawn(collision.gameObject));
        }
    }
    private void Start()
    {
        targetDown = false;
        maxVelocity = new Vector2(0f,0f);
    }
    private void Update()
    {
        if (targetDown)
        {
            maxVelocity.y = Mathf.Max(targetRb.velocity.y,maxYSpeed);
            targetRb.velocity = maxVelocity;
            targetRb.gravityScale -= Time.deltaTime * lessSpeed;
            if (targetRb.gravityScale < 0.1f)
            {
                targetRb.gravityScale = 0f;
                targetRb.velocity = new Vector2(0f, 0f);
                Piranha.chaseTarget = true;
                Piranha.target = targetRb.transform;
                targetDown = false;
            }
        }
    }
    IEnumerator waitRespawn(GameObject objectToDisactive)
    {
        yield return new WaitForSeconds(4f);
        targetRb.gravityScale = 2f;
        PlayerMovement.needRespawn = true;
        objectToDisactive.SetActive(false);
    }
}
