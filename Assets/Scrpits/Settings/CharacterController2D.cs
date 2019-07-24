using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;
public class CharacterController2D : MonoBehaviour
{

    [SerializeField] private float m_JumpForce = 500f;							// Amount of force added when the player jumps.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

    const float k_GroundedRadius = .05f; // Radius of the overlap circle to determine if grounded
    public static bool m_Grounded, doChecking;            // Whether or not the player is grounded.
    private Rigidbody2D m_Rigidbody2D;
    public Animator animator;
    public static bool m_FacingRight;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    private void Awake()
    {
        m_Grounded = true;
        m_FacingRight = true;
        doChecking = false;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator.SetBool("Grounded",true);
        //Flip player in scenes where player should face the left when initializing
        //if player should face the right at awake , then no need to flip 
        if (new string[] {"Level 1-3","Level 2-1","Level 2-2","Level 2-3" }.Contains(SceneManager.GetActiveScene().name))
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        m_Grounded = false;
        animator.SetBool("Grounded", false);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject && new string[] { "Ground", "Moving Platform" }.Contains(colliders[i].transform.tag))
            {
                animator.SetBool("Grounded", true);
                m_Grounded = true;
                break;
            }
        }
        if (!m_Grounded )
        {
            doChecking = true;
        }
        if (doChecking && m_Grounded)
        {
            animator.SetTrigger("Landing");
            doChecking = false;
        }
    }

    public void Move(float move, bool jump)
    {
           // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 5f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }

        // If the player should jump...
        if (m_Grounded && jump)
        {
            m_Grounded = false;
            animator.SetBool("Grounded", false);
        }
    }
    public IEnumerator Jump()
    {
        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        yield return new WaitForSeconds(0.15f);
        doChecking = true;

    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f,180f,0f);
    }
}
