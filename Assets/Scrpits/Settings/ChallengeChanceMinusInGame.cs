using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChallengeChanceMinusInGame : MonoBehaviour
{
    public GameObject[] thingsToDisplay;
    public TextMeshProUGUI mainText;
    public Text[] numberTexts;
    public Animator canvasAnim;
    private float time;
    private void Start()
    {
        time = 2f;
        numberTexts[0].text = (PlayerPrefs.GetInt("TrialChanceLeft", 3) + 1).ToString();
        numberTexts[1].text = PlayerPrefs.GetInt("TrialChanceLeft", 3).ToString();
        StartCoroutine(DisplayThenWait());
    }
    // Update is called once per frame
    void Update()
    {
        if (time > 0.01f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            canvasAnim.SetTrigger("FadeOut");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator DisplayWordByWord(TextMeshProUGUI tmpText, string key)
    {
        string sentence = LocalizationManager.Instance.GetText(key);
        yield return null;
        tmpText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            tmpText.text += letter;
            yield return null;
        }
    }
    IEnumerator DisplayThenWait()
    {
        for (int i = 0; i <= 3; i++)
        {
            thingsToDisplay[i].SetActive(true);
            switch (i)
            {
                case 0:
                    StartCoroutine(DisplayWordByWord(mainText, "CHALLENGECHANCE"));
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.4f);
        }
    }
}
