using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpCollider : EnemyGeneral {
    private Vector2[] points0;
    private Vector2[] points1;
    private Vector2[] points2;
    private PolygonCollider2D polyCollider;
    // Use this for initialization
    void Start() {
        polyCollider = GetComponent<PolygonCollider2D>();
        points0 = polyCollider.GetPath(0);
        points1 = new Vector2[] 
        {
            new Vector2(0.93f, 1.14f),
            new Vector2(-0.04f, 0.29f),
            new Vector2(-1.55f, 0.20f),
            new Vector2(-1.77f, -0.3f),
            new Vector2(-1.23f, -1.17f),
            new Vector2(-0.51f, -1.58f),
            new Vector2(-1.43f, -2.26f),
            new Vector2(-1.56f, -1.45f),
            new Vector2(-2.01f, -1.11f),
            new Vector2(-2.48f, -0.02f),
            new Vector2(-2.14f, 0.87f),
            new Vector2(0.24f, 1.97f)
        };
        points2 = new Vector2[]
        {
            new Vector2(0.86f,1.32f),
            new Vector2(0f,0.36f),
            new Vector2(-1.55f,0.20f),
            new Vector2(-1.77f,-0.30f),
            new Vector2(-1.49f,-1.48f),
            new Vector2(-1.02f,-2.16f),
            new Vector2(-2.01f, -2.43f),
            new Vector2(-1.86f, -1.62f),
            new Vector2(-2.24f, -1.11f),
            new Vector2(-2.48f, -0.02f),
            new Vector2(-2.14f, 0.87f),
            new Vector2(0.18f, 2.13f)
        };
        //enemyHealth = 3;
	}
	
    public void changeCollider0()
    {
        polyCollider.SetPath(0,points0);
    }
    public void changeCollider1()
    {
        polyCollider.SetPath(0, points1);
    }
    public void changeCollider2()
    {
        polyCollider.SetPath(0, points2);
    }
}
