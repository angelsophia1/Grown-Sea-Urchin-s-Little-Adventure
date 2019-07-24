using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour {
    public Transform stoneSpawnPoint;
    public GameObject fallingStones;
    private float timer = 0f;
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0f)
        {
            Instantiate(fallingStones, stoneSpawnPoint.transform.position, Quaternion.identity);
            timer = 4f;
        }

    }
}
