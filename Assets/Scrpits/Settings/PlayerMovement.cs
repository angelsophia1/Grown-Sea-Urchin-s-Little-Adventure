using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using System.Linq;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public Animator animator;
    public float runSpeed = 6f;
    public static bool needRespawn, canMove , canJump,canView, needHeal, immuneDamage;
    public GameObject deathObject;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    private const float k_GroundedRadius = .05f;
    private float horizontalMove = 0f, immuneCountDownTime = 1f;
    private bool jump;
    private Color color;
    private void Start()
    {
        color = new Color(1f,1f,1f);
        needRespawn = false;
        canMove = true;
        canView = true;
        jump = false;
        immuneDamage = false;
        canJump = true;
        needHeal = false;
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump") && canMove && canJump)
        {
            jump = true;
            animator.SetTrigger("Jump");
            canJump = false;
        }
        if (immuneDamage)
        {
            immuneCountDownTime -= Time.deltaTime;
            if (immuneCountDownTime<0f)
            {
                immuneDamage = false;
                immuneCountDownTime = 1f;
            }
        }
    }
    void FixedUpdate()
    {
        // Move our character
        if (canMove)
        {
            GetComponent<CharacterController2D>().Move(horizontalMove * Time.fixedDeltaTime, jump);
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        jump = false;
        animator.SetFloat("Y_Speed", playerRigidbody.velocity.y);
    }
    public void LandingOver()
    {
        canJump = true;
    }
    IEnumerator ImmuneOver()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.1f);
            ChangeColorAlpha(0.8f);
            yield return new WaitForSeconds(0.1f);
            ChangeColorAlpha(0.4f);
        }
        yield return new WaitForSeconds(0.1f);
        ChangeColorAlpha(0.8f);
        yield return new WaitForSeconds(0.1f);
        ChangeColorAlpha(1f);

        //immuneDamage = false;

    }
    void ChangeColorAlpha(float alpha)
    {
        color.a = alpha;
        GetComponent<SpriteRenderer>().color = color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag( "Moving Platform" ))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (new string[] { "Moving Platform" }.Contains(colliders[i].transform.tag))
                {
                    transform.parent = collision.transform;
                }
            }
        }
        else if (collision.transform.CompareTag("Hurt Obstacles"))
        {
            needRespawn = true;
            Instantiate(deathObject,transform.position,Quaternion.identity);
            gameObject.SetActive(false);

        }else if (new string[] {  "FallingStones","NoTriggerObstacles","Enemy Body"}.Contains(collision.transform.tag) && (!immuneDamage))
        {
            FindObjectOfType<GameManager>().TakeDamage();
            StartCoroutine(FindObjectOfType<CameraManager>().Shake(0.1f, 0.2f));
            immuneDamage = true;
            StartCoroutine(ImmuneOver());
        }
        else if (collision.transform.CompareTag("Heart"))
        {
            needHeal = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!immuneDamage)
        {
            if (new string[] {  "Circle Obstacles","TriggerObstacles" }.Contains(collision.transform.tag))
            {
                FindObjectOfType<GameManager>().TakeDamage();
                StartCoroutine(FindObjectOfType<CameraManager>().Shake(0.1f, 0.2f));
                immuneDamage = true;
                StartCoroutine(ImmuneOver());
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Moving Platform") )
        {
            transform.parent = null;
        }

    }
    public GameObject GetDeathParticle()
    {
        return deathObject;
    }
}

