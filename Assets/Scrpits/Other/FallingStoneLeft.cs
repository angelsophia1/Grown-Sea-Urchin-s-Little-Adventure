using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class FallingStoneLeft : MonoBehaviour
{
    public GameObject destroyParticleStone;
    private bool needRolling = false;
    private float changeDirection = -1f;
    private Vector2 velocityRight = new Vector2(2f, 0f);
    private Rigidbody2D rb2D;
    private float rotateSpeed = 180f;
    private void Start()
    {
        StartCoroutine(delayDestroy());

    }


    private void Update()
    {
        if (needRolling == true)
        {
            rb2D = GetComponent<Rigidbody2D>();
            rb2D.velocity = velocityRight * changeDirection;
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime * changeDirection);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (new string[] { "Hurt Obstacles" }.Contains(collision.transform.tag))
        {
            Instantiate(destroyParticleStone, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else if (collision.transform.CompareTag( "Ground"))
        {
            needRolling = true;
        }
        else if (collision.transform.CompareTag( "FallingStones"))
        {
            changeDirection = 1f;
        }
        else if (new string[] { "Circle Obstacles", "Player" }.Contains(collision.transform.tag))
        {
            StartCoroutine(delayDisignoreCollsion(collision.collider,gameObject));
        }
    }
    IEnumerator delayDisignoreCollsion(Collider2D playerCollider2D,GameObject collideStone)
    {
        Physics2D.IgnoreCollision(playerCollider2D,collideStone.GetComponent<Collider2D>());
        yield return new WaitForSeconds(0.9f);
        Physics2D.IgnoreCollision(playerCollider2D, collideStone.GetComponent<Collider2D>(),false);
    }
    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
