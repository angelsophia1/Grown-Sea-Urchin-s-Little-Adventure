using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public GameObject destroyGrenadeParticle;
    public float reverseDirection;
    private GameObject playerDeathParticle;
    private float countDown = 1.5f, radius = 1.5f, torqueForce = -10f;
    private bool isGrounded = false, hasExploded = false;
	
	// Update is called once per frame
	void Update () {
        countDown -= Time.deltaTime;
        if (countDown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
	}
    public void Explode()
    {
        Instantiate(destroyGrenadeParticle,transform.position,Quaternion.identity);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,radius);
        foreach (Collider2D nearObject in colliders)
        {

            if (nearObject.transform.CompareTag("Player"))
            {
                PlayerMovement.needRespawn = true;
                playerDeathParticle = nearObject.GetComponent<PlayerMovement>().GetDeathParticle();
                Instantiate(playerDeathParticle,nearObject.transform.position,Quaternion.identity);
                nearObject.gameObject.SetActive(false);
            }else if (nearObject.transform.CompareTag("Grenade")&&nearObject.gameObject !=gameObject)
            {
                Destroy(nearObject.gameObject);
            }
        }
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag( "Ground" )&& !isGrounded)
        {
            //Spawn right grenade use negative torque force (clockwise)[positive torque force : anticlockwise].
            GetComponent<Rigidbody2D>().AddTorque(torqueForce * reverseDirection);
            isGrounded = true;
        }
    }
}
