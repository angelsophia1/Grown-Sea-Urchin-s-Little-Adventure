using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneral : MonoBehaviour {
    public GameObject  enemyDestroyPrefab, enemyBloodPrefab, enemyDrops;
    protected int enemyHealth = 2;
    private float forceTimes = 15f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spine"))
        {
            TakeDamage(collision);
        }
    }
    private void TakeDamage(Collider2D collision)
    {
        if (enemyHealth >1)
        {
            enemyHealth--;
            Instantiate(enemyBloodPrefab, collision.transform.position, collision.transform.rotation);
        }
        else
        {
            Instantiate(enemyDestroyPrefab,transform.position,Quaternion.identity);
            ItemToDrop();
            Destroy(gameObject);
        }
    }
    private void ItemToDrop()
    {
        int randomNumber = Random.Range(0, 3);
        switch (randomNumber)
        {
            case 2:
                break;
            default:
                GameObject itemToDrop = Instantiate(enemyDrops, transform.position, Quaternion.identity);
                int randomDirection = Random.Range(0, 3);
                switch (randomDirection)
                {
                    case 0:
                        itemToDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f, 3f) * forceTimes);
                        break;
                    case 1:
                        itemToDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3f, 3f) * forceTimes);
                        break;
                    case 2:
                        itemToDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4.24f) * forceTimes);
                        break;
                    default:
                        Debug.Log("No approriate number to add force.");
                        break;
                }
                break;
        }
    }
}
