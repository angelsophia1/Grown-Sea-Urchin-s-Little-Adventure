using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionScene : MonoBehaviour {
    public static bool introOver ;
    public GameObject introScene;
    public void Awake()
    {
        introOver = false;
    }
    //public void CallIntro()
    //{
    //    introScene.SetActive(true);
    //}
    public void IntroStart()
    {
        PlayerMovement.canMove = false;
    }
    public void IntroOver()
    {
        introOver = true;
        PlayerMovement.canMove = true;
        introScene.SetActive(false);
    }

}
