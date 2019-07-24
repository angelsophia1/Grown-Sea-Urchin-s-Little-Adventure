using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DropTriangle : MonoBehaviour {
    public GameObject trap, dropTriangleDestroyParticle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (new string[] {"Player","Ground" }.Contains(collision.transform.tag))
        {
            Instantiate(dropTriangleDestroyParticle,transform.position,Quaternion.identity);
            Destroy(trap);
        }
    }
}
