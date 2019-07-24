using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMainMenu : MonoBehaviour {
    //Before launching, please do the following to delete all test data
    //private void Start()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
    public void LoadMap()
    {
        SceneManager.LoadScene("Map");
    }
}
