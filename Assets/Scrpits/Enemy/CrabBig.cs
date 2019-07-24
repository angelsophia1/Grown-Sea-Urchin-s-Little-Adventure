using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBig : MonoBehaviour {
    public GameObject spineDestoryPrefab, enemyDestroyPrefab, enemyBloodPrefab, enemy, dropPrefab, bubblePrefab, laserPrefab;
    public Transform dropPoint, BubblePoint;
    public Transform[] laserPoints;
    private GameObject laserClone;
    private float timeBetweenDrops=0.55f;
    private float timeBetweenBubbles = 0.25f;
    private float timeForSpine = 0.35f;
    private float timeForBlood = 0.5f;
    private int enemyHealth = 5;
    private int i;
    private bool needSpawnDrops = false;
    private bool needSpawnBubble = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag( "Spine"))
        {
            GameObject spineDestroyClone = Instantiate(spineDestoryPrefab, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            StartCoroutine(DestroyAfterInstantiate(spineDestroyClone, timeForSpine));
            TakeDamage(collision);
        }
    }
    IEnumerator DestroyAfterInstantiate(GameObject clone, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(clone);
    }
    void TakeDamage(Collider2D collision)
    {
        if (enemyHealth > 0)
        {
            enemyHealth--;
            GameObject enemyBloodClone = Instantiate(enemyBloodPrefab, collision.transform.position, collision.transform.rotation);
            StartCoroutine(DestroyAfterInstantiate(enemyBloodClone, timeForBlood));
        }
        else
        {
            if (laserClone!=null)
            {
                Destroy(laserClone);
            }
            Instantiate(enemyDestroyPrefab, transform.position, Quaternion.identity);
            Destroy(enemy);
        }
    }

    private void Update()
    {
        if (laserClone != null)
        {
            Rigidbody2D rb = laserClone.GetComponent<Rigidbody2D>();
            switch (i)
            {
                case 0:
                    rb.velocity = new Vector3(2.5f, 0f, 0f);
                    if (Vector3.Distance(laserClone.transform.position, laserPoints[1].position) < 0.01f)
                    {
                        i++;
                    }
                    break;
                case 1:
                    rb.velocity = new Vector3(-2.5f, 0f, 0f);
                    if (Vector3.Distance(laserClone.transform.position, laserPoints[0].position) < 0.01f)
                    {
                        i--;
                    }
                    break;
                default:
                    Debug.Log("No approriate case for index i.");
                    break;

            }
        }
        if (needSpawnDrops)
        {
            timeBetweenDrops += Time.deltaTime;
            if (timeBetweenDrops >= 0.55f)
            {
                Instantiate(dropPrefab, dropPoint.position, Quaternion.identity);
                timeBetweenDrops = 0f;
            }
        }
        if (needSpawnBubble)
        {
            timeBetweenBubbles += Time.deltaTime;
            if (timeBetweenBubbles >= 0.35f)
            {
                Instantiate(bubblePrefab, BubblePoint.position, Quaternion.identity);
                timeBetweenBubbles = 0f;
            }
        }
    }
    public void SpawnDropsTrue()
    {
        needSpawnDrops = true;
    }
    public void SpawnDropsFalse()
    {
        needSpawnDrops = false;
    }
    public void SpawnBubbleTrue()
    {
        needSpawnBubble = true;
    }
    public void SpawnBubbleFalse()
    {
        needSpawnBubble = false;
    }
    public void SpawnLaser()
    {
        if (laserClone == null)
        {
            i = Random.Range(0, 2);
            laserClone = Instantiate(laserPrefab,laserPoints[i].position,Quaternion.identity);
        }
    }
    public void DestroyLaser()
    {
        Destroy(laserClone);
    }
}
