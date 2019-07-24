using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Timer : MonoBehaviour {
    public Text timerText;
    public static bool trialOver = false;
    public float startTime;
    public float t;
    public bool tempStart;
    private string minutes;
    private string seconds;
    private void Awake()
    {
        trialOver = false;
        tempStart = true;
        t = 0f;
    }

    // Update is called once per frame
    void Update () {
        if (IntroductionScene.introOver)
        {
            if (tempStart)
            {
                startTime = Time.time;
                tempStart = false;
            }
            t = Time.time - startTime;
            if (t < 60f)
            {
                if (t < 0.7f)
                {
                    timerText.text = "1:00";
                }
                else
                {
                    //minutes = (1 - (int)t / 60).ToString();
                    minutes = "0";
                    if (t % 60 != 0)
                    {
                        seconds = (60 - (t % 60)).ToString("f0");
                        if (new string[] { "9", "8", "7", "6", "5", "4", "3", "2", "1" }.Contains(seconds))
                        {
                            seconds = "0" + seconds;
                        }

                    }
                    else
                    {
                        seconds = "00";
                    }


                    timerText.text = minutes + ":" + seconds;
                }




            }
            else
            {
                timerText.text = "0:00";
            }
            if (t >= 60f)
            {
                trialOver = true;
            }
        }
        if (trialOver)
        {
            FindObjectOfType<GameManager>().DetermineOver();
        }
        if (FindObjectOfType<FlagExit>().GetLevelOver())
        {
            gameObject.SetActive(false);
        }
    }


}
