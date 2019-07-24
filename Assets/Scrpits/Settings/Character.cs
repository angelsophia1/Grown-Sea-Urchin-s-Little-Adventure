using UnityEngine;
public class Character
{
    public int fileNumber;
    public int newBeginning;
    public int abilityIntroDisplayed;
    public int cutScene1;
    public int cutScene2;
    public int coinsCollected;
    public int trialChanceLeft;
    public int levelCleared;
    //public Character(int fileNumber, int newBeginning,int abilityIntroDisplayed, int cutScene1, int cutScene2, int coinsCollected, int trialChanceLeft, int levelCleared)
    public Character(int fileNumber)
    {
        this.fileNumber = fileNumber;
        newBeginning = PlayerPrefs.GetInt("NewBeginning", 0);
        abilityIntroDisplayed = PlayerPrefs.GetInt("AbilityIntroDisplayed", 0);
        cutScene1 = PlayerPrefs.GetInt("CutScene1", 1);
        cutScene2 = PlayerPrefs.GetInt("CutScene2", 1);
        coinsCollected = PlayerPrefs.GetInt("CoinsCollected", 0);
        trialChanceLeft = PlayerPrefs.GetInt("TrialChanceLeft", 3);
        levelCleared = PlayerPrefs.GetInt("LevelCleared", 0);
        //this.newBeginning = newBeginning;
        //this.abilityIntroDisplayed = abilityIntroDisplayed;
        //this.cutScene1 = cutScene1;
        //this.cutScene2 = cutScene2;
        //this.coinsCollected = coinsCollected;
        //this.trialChanceLeft = trialChanceLeft;
        //this.levelCleared = levelCleared;
    }
}
