using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AttackController : MonoBehaviour {
    public Transform[] spineSpawnPoints;
    public GameObject spine;
    public static int attackCount;
    public static float attackPoweringTime;
    private Animator anim;
    private Color color;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        color = new Color(1f,1f,1f);
        attackPoweringTime = 2f;
        attackCount = 3;
    }
	
	// Update is called once per frame
	void Update () {
        //if attack ability (playerpref.getint) acquired, then do following attack check
        if (PlayerPrefs.GetInt("AbilityIntroDisplayed",0)>=3)
        {
            if (CharacterController2D.m_Grounded && attackCount > 0 && PlayerMovement.canMove && PlayerMovement.canJump)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)||Input.GetButtonDown("Attack"))
                {
                    anim.SetTrigger("Attack");
                    PlayerMovement.canMove = false;
                }
            }
            if (attackCount < 3)
            {
                attackPoweringTime -= Time.deltaTime;
                if (attackPoweringTime < 0.01f)
                {
                    attackCount++;
                    attackPoweringTime = 2f;
                }
            }
        }
    }
    void FireNow()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(spine, spineSpawnPoints[i].position, spineSpawnPoints[i].rotation);
        }
        PlayerMovement.canMove = true;
        attackCount--;
    }

    void ChangeColorAlpha(float alpha)
    {
        color.a = alpha;
        GetComponent<SpriteRenderer>().color = color;
    }


}
