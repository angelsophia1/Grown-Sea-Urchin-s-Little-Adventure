using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Bubble : MonoBehaviour {
    public GameObject bubbleDestroyPrefab;
    private int index;
    private float velocityTimes=0.5f;
    private float timeDestroy = 2.5f;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        index = Random.Range(0,8);
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (index)
        {
            case 0:
                rb.velocity = new Vector3(-4.33f,-2.5f,0f) * velocityTimes;
                break;
            case 1:
                rb.velocity = new Vector3(-3f,-4f,0f) * velocityTimes;
                break;
            case 2:
                rb.velocity = new Vector3(0f, -5f, 0f) * velocityTimes;
                break;
            case 3:
                rb.velocity = new Vector3(3f,-4f,0f) * velocityTimes;
                break;
            case 4:
                rb.velocity = new Vector3(4.33f,-2.5f,0f) * velocityTimes;
                break;
            case 5:
                goto case 1;
            case 6:
                goto case 2;
            case 7:
                goto case 3;
            default:
                Debug.Log("No appropriate case for index.");
                break;
        }
        timeDestroy -= Time.deltaTime;
        if (timeDestroy<=0f)
        {
            Destroy(gameObject);
        }
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (new string[] { "Player", "Ground" }.Contains(collision.transform.tag))
        {
            Instantiate(bubbleDestroyPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
