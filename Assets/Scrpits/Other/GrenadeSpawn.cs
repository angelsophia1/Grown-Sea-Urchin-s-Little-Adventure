using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpawn : MonoBehaviour
{
    public Transform grenadeSpawnPoint;
    public GameObject grenade;
    public float waitTime;
    private float timer = 3.5f;
    private void Start()
    {
        timer += waitTime;
    }
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer < 0f)
        {
            Instantiate(grenade, grenadeSpawnPoint.transform.position, Quaternion.identity);
            timer = 3.5f;
        }

    }
}
