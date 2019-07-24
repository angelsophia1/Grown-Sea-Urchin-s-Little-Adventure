using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrops : MonoBehaviour {
    public GameObject dropPrefab;
    public Transform dropPoint;
    private float timer = 0.75f;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer>=0.75f)
        {
            Instantiate(dropPrefab,dropPoint.position,Quaternion.identity);
            timer =0f;
        }
	}
}
