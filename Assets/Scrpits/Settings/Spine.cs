using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spine : MonoBehaviour {
    public float speed = 7f;
    public GameObject spineDestroyPrefab;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(waitDestroy());
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.up * speed;
	}
    IEnumerator waitDestroy()
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy Body"))
        {
            Instantiate(spineDestroyPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
