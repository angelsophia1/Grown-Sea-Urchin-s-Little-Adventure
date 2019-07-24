using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    public GameObject heartDestroyPrefab;
    private Animator anim;
    private float existTime = 3f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Instantiate(heartDestroyPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (existTime > 0 )
        {
            existTime -= Time.deltaTime;
        }
        else
        {
            anim.SetTrigger("Disappear");
        }
    }
    public void destroyItself()
    {
        Destroy(gameObject);
    }
}
