using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCrabStone : MonoBehaviour {
    public GameObject stoneDestroyParticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag ("Ground"))
        {
            Destroy(gameObject);
            Instantiate(stoneDestroyParticle,transform.position,Quaternion.identity);
        }
    }

}
