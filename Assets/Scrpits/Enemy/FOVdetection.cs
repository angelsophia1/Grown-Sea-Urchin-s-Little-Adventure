using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVdetection : MonoBehaviour {
    public float maxRadius, maxAngle;
    public Animator shrimp;
    private bool isinFov = false, needPosition = true, attack = false, goUp = false, facingRight = true;
    private Vector3 targetPosition;
    private float maxDistance = 0.05f, startYAxis, moveTime = 2f, moveSpeed = 20f;
    private Rigidbody2D rb;
    private Transform player;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.forward) * transform.right * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.forward) * transform.right * maxRadius;
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);
        if (isinFov)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.right * maxRadius);

    }
    public void inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        isinFov = false;
        Collider2D[] overlaps = new Collider2D[10];
        //can use the following if only detect player
        //int layerMaskPlayer = 1 << 9;
        //int count = Physics2D.OverlapCircleNonAlloc(checkingObject.position, maxRadius, overlaps, layerMaskPlayer);
        int count = Physics2D.OverlapCircleNonAlloc(checkingObject.position, maxRadius, overlaps);
        for (int i = 0; i < count; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform.CompareTag("Player"))
                {
                    Vector2 directionBetween = (target.position - checkingObject.position).normalized;
                    float angle = Vector2.Angle(checkingObject.right, directionBetween);
                    if (angle <= maxAngle)
                    {
                        int layerMask = ~(1<<8);
                        RaycastHit2D hit = Physics2D.Raycast(checkingObject.position, target.position - checkingObject.position, maxRadius,layerMask);
                        if (hit.collider != null)
                        {
                            if (hit.transform == target)
                            {
                                isinFov = true;
                            }

                        }
                    }
                }
            }
        }
    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startYAxis = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        inFOV(transform, player, maxAngle, maxRadius);
        if (isinFov)
        {
            if (needPosition)
            {
                targetPosition = player.position;
                needPosition = false;
                attack = true;
                shrimp.SetBool("Attack", true);
                shrimp.SetBool("Go Up", false);

            }
        }
        if (attack)
        {
            Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, targetPosition, maxDistance);
            transform.position = smoothedPosition;
            float distanceBetween = Vector3.Distance(transform.position, targetPosition);
            if (distanceBetween < 0.01f)
            {
                attack = false;
                goUp = true;
                shrimp.SetBool("Attack", false);
                shrimp.SetBool("Go Up", true);
            }
        }
        if (goUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            if (startYAxis - transform.position.y < 0.1f)
            {
                goUp = false;
                StartCoroutine(waitForNextAttack());
            }
        }
        if (!(goUp||attack))
        {
            if (facingRight)
            {
                rb.velocity = new Vector2(moveSpeed * Time.deltaTime, 0f);
                moveTime -= Time.deltaTime;
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, 0f);
                moveTime -= Time.deltaTime;
            }
            if (moveTime < 0.01f)
            {
                moveTime = 2f;
                Flip();
            }

        }
    }
    IEnumerator waitForNextAttack()
    {
        yield return new WaitForSeconds(0.5f);
        needPosition = true;
    }
    private void Flip ()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }
}
