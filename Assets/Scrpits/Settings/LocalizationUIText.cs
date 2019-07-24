using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LocalizationUIText : MonoBehaviour
{

    public TMP_FontAsset English;
    public TMP_FontAsset Chinese;
   
    public string key;

    void Start()
    {
        // Get the string value from localization manager from key 
        // and set the text component text value to the  returned string value 
        GetComponent<TextMeshProUGUI>().text = LocalizationManager.Instance.GetText(key);
        if (GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>().currentLanguageID == 0)
        {
            GetComponent<TextMeshProUGUI>().font = English;
        }
        if (GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>().currentLanguageID == 1)
        {
            GetComponent<TextMeshProUGUI>().font = Chinese;
        }
    }
}