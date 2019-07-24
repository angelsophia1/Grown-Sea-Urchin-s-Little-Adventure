using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemyDrops : MonoBehaviour {
    public GameObject dropDestroyParticle;
    private float rotateSpeed=-270f;
	// Use this for initialization
	void Start () {
        StartCoroutine(destroyAfterInstantiate());
	}
    private void Update()
    {
        transform.Rotate(0f,0f,rotateSpeed*Time.deltaTime);
    }
    IEnumerator destroyAfterInstantiate()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(dropDestroyParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (new string[] { "Player", "Ground" }.Contains(collision.transform.tag))
        {
            Instantiate(dropDestroyParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
