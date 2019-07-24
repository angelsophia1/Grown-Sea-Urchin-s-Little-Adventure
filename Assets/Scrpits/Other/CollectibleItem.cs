using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class CollectibleItem : MonoBehaviour {
    private float rotateSpeed=90f;
    public GameObject destroyPrefab;
    // Use this for initialization
    private void Update()
    {
        transform.Rotate(0,rotateSpeed*Time.deltaTime,0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag( "Player"))
        {
            FindObjectOfType<AudioManager>().Play("Coin Collected");
            Instantiate(destroyPrefab, transform.position, Quaternion.identity);
            GameManager.itemsCollected++;
            Destroy(gameObject);

        }
    }
}
