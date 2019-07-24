using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : MonoBehaviour {
    public static bool chaseTarget;
    public static Transform target;
    public Transform bloodPostion;
    public GameObject bloodParticlePrefab;
    private Rigidbody2D rb;
    private float minTime = 1f, maxTime = 2f, moveTime, moveSpeed = -2f,maxDistance = 0.1f, distanceBetween;
    private int randomNum;
    private bool faceLeft, chaseOver, needDirection, needEatAction;
    private Animator anim;
    private Vector3 offsetLeft = new Vector3 (-0.4f,0f,0f);
    private Vector3 offsetRight = new Vector3(0.4f,0f,0f);
    private void Start()
    {
        chaseTarget = false;
        chaseOver = false;
        needDirection = true;
        needEatAction = false;
        rb = GetComponent<Rigidbody2D>();
        moveTime = Random.Range(minTime, maxTime);
        randomNum = Random.Range(0, 2);
        anim = GetComponent<Animator>();
        switch (randomNum)
        {
            case 0:
                faceLeft = true;
                break;
            case 1:
                faceLeft = false;
                break;
            default:
                faceLeft = true;
                break;
        }
        if (!faceLeft)
        {
            transform.Rotate(0f, 180f, 0f);
            moveSpeed *= -1f ;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!chaseTarget)
        {
            if (needEatAction)
            {
                anim.SetBool("Eat", false);
                needEatAction = false;
                if (faceLeft)
                {
                    if (moveSpeed > 0)
                    {
                        faceLeft = !faceLeft;
                        transform.Rotate(0f, 180f, 0f);
                    }
                }
                else
                {
                    if (moveSpeed < 0)
                    {
                        faceLeft = !faceLeft;
                        transform.Rotate(0f, 180f, 0f);
                    }
                }
            }
            if (moveTime > 0f)
            {
                rb.velocity = new Vector3(1f, 0f, 0f) * moveSpeed;
                moveTime -= Time.deltaTime;
            }
            else
            {
                moveTime = Random.Range(minTime, maxTime);
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector3(0f,0f,0f);
            if (!chaseOver)
            {
                if (needDirection)
                {
                    if ((target.position - transform.position).x > 0f)
                    {
                        if (faceLeft)
                        {
                            faceLeft = !faceLeft;
                            transform.Rotate(0f, 180f, 0f);
                        }
                    }
                    else
                    {
                        if (!faceLeft)
                        {
                            faceLeft = !faceLeft;
                            transform.Rotate(0f, 180f, 0f);
                        }
                    }
                    needDirection = false;
                    needEatAction = true;
                }
                if ((target.position - transform.position).x > 0f)
                {
                    Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, target.position + offsetLeft, maxDistance);
                    transform.position = smoothedPosition;
                    distanceBetween = Vector3.Distance(transform.position, target.position + offsetLeft);
                }
                else
                {
                    Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, target.position + offsetRight, maxDistance);
                    transform.position = smoothedPosition;
                    distanceBetween = Vector3.Distance(transform.position, target.position + offsetRight);
                }
                if (distanceBetween < 0.5f)
                {
                    anim.SetBool("Eat",true);                   
                    chaseOver = true;
                    StartCoroutine(EatOver());
                }
            }
        }
    }
    void Flip()
    {
        faceLeft = !faceLeft;
        transform.Rotate(0f, 180f, 0f);
        moveSpeed *= -1f;
    }
    IEnumerator EatOver()
    {
        yield return new WaitForSeconds(2f);
        chaseTarget = false;
        chaseOver = false;
        needDirection = true;
    }
    public void InstantiateBlood()
    {
        Instantiate(bloodParticlePrefab,bloodPostion.position,Quaternion.identity);
    }
}
