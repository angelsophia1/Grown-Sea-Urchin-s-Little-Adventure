using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public GameObject restartMenu, player, trialOver,challengeChanceMinus;
    public GameObject[] checkPoints;
    public Animator canvasAnim;
    public SpriteRenderer[] hearts;
    public Sprite heartErased, heartFulfilled;
    public static int itemsCollected, checkPointIndex;
    private int num ;
    private Color color;
    private void Awake()
    {
        num = 2;
        checkPointIndex = 0;
        itemsCollected = 0;
        color = new Color(1f,1f,1f);
        color.a = 1f;
    }
    private void Update()
    {
        if (PlayerMovement.needRespawn == true)
        {
            PlayerMovement.needRespawn = false;
            if (num >= 1 )
            {
                StartCoroutine(Respawn());                
            }
            else
            {
                DetermineOver();
            }
        }
        if (PlayerMovement.needHeal)
        {
            if (num < 2 )
            {
                num++;
                hearts[num].sprite = heartFulfilled;
            }
            PlayerMovement.needHeal = false;
        }
    }   
    IEnumerator Respawn()
    {
        PlayerMovement.canJump = true;
        CharacterController2D.doChecking = false;
        yield return new WaitForSeconds(0.5f);
        player.transform.position = checkPoints[checkPointIndex].transform.position;
        player.GetComponent<SpriteRenderer>().color = color;
        player.transform.parent = null;
        player.SetActive(true);
        hearts[num].sprite = heartErased;
        num--;       
    }
    public void DetermineOver()
    {
        if (!Timer.trialOver)
        {
            hearts[num].sprite = heartErased;
        }
        if (PlayerPrefs.GetInt("TrialChanceLeft", 3) >=1)
        {
            StartCoroutine(WaitGameOver());
        }
        else
        {
            StartCoroutine(WaitStartOver());
        }
    }
    IEnumerator WaitGameOver()
    {
        yield return new WaitForSeconds(0.25f);
        canvasAnim.SetBool("Appear", true);
        Time.timeScale = 0f;
        restartMenu.SetActive(true);
        FindObjectOfType<InGameEventSystem>().SelectFirst(1);
    }
    IEnumerator WaitStartOver()
    {
        yield return new WaitForSeconds(0.25f);
        canvasAnim.SetBool("Appear",true);
        trialOver.SetActive(true);
        FindObjectOfType<InGameEventSystem>().SelectFirst(2);
        Time.timeScale = 0f;

    }
    public void RestartButton()
    {
        PlayerPrefs.SetInt("TrialChanceLeft", PlayerPrefs.GetInt("TrialChanceLeft", 3) - 1);
        FindObjectOfType<PausedMenu>().SaveFile(MainMenu.fileNumber);
        //canvasAnim.SetTrigger("FadeOut");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        challengeChanceMinus.SetActive(true);
        Time.timeScale = 1f;
    }
    public void TakeDamage()
    {
        if (num > 0)
        {
            hearts[num].sprite = heartErased;
            num--;
        }
        else
        {
            DetermineOver();
        }
    }
    
}
