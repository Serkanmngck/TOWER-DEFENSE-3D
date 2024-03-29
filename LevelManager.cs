using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static Enemy_Controller;


[System.Serializable]
public class Level
{
    public int LevelID;
    public bool isLocked;
    public int levelScore=-1;
}



public class LevelManager : MonoBehaviour
{
   
    public static LevelManager Instance;
    [SerializeField] private List<Level> levels= new List<Level>();
    private bool hasShownLevelData = false;
    private int Diamond=5;
    private int skill1;
    private int currentLevelid;
    public float volume=2;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
        getDiamond();
        getSkill();
        foreach (Level level in levels)
        {  
            //UpdateLevelData(level.LevelID);
        }
        UpdateLevelLocked(1, true);

        
    }

    public int currnetlevel()
    {
        foreach (Level level in levels)
        {
            if(!level.isLocked)
            {
                currentLevelid = level.LevelID-1;
                return currentLevelid;
            }
        }
        return 0;
    }
    public void addDiamond(int add)
    {
        Diamond += add;
        SaveDiamond(Diamond);
    }
    public string ShowDiamond()
    {
        return Diamond.ToString();
    }
    public string ShowSkill()
    {
        return skill1.ToString();
    }
    private void UpdateLevelData(int levelID)
    {
        int looktemp = PlayerPrefs.GetInt("Level" + levelID.ToString() + "Locked");
        bool look = looktemp == 0 ? false : true;
        int score = PlayerPrefs.GetInt("Level" + levelID.ToString() + "Score");

        Debug.Log("Level " + levelID + " - Locked: " + look + ", Score: " + score);

        Level templevel = levels.Find(level => level.LevelID == levelID);
        if (templevel != null)
        {
            templevel.isLocked = look;
            templevel.levelScore = score;
        }
    }
    public void UpdateLevelLocked(int levelID,bool lLoocked)
    {

        Level templevel = levels.Find(level => level.LevelID == levelID);
        if (templevel != null)
        {
            templevel.isLocked = lLoocked;
        }
        SaveLevel(levelID);
    }
    public void UpdateLevelscore(int levelID, int score)
    {


        Level templevel = levels.Find(level => level.LevelID == levelID);
        if (templevel != null)
        {
            templevel.levelScore = score;
        }
        SaveLevel(levelID);
    }
    public void UnlockLevel(int levelID)
        {
            Level templevel = levels.Find(level => level.LevelID == levelID);
            if (templevel != null) 
            {
                templevel.isLocked = false;
            }

        }

    public bool IsLevelLucked(int levelID)
     {
        Level templevel = levels.Find(level => level.LevelID == levelID);
        if (templevel != null)
        {
            return templevel.isLocked;
        }
        return false;
     }
    public int LevelScore(int levelID)
    {
        Level templevel = levels.Find(level => level.LevelID == levelID);
        if (templevel != null)
        {
            return templevel.levelScore;
        }
        return -1;
    }
    public void SaveDiamond(int diamond)
    {

        PlayerPrefs.SetInt("Diamond" , diamond);
    }
    public void SaveSkill(int skill1)
    {
        PlayerPrefs.SetInt("Skill1", skill1);
    }
    public void getSkill()
    {
        int temp = PlayerPrefs.GetInt("Skill1", skill1);
        skill1 = temp;
    }
    public void addSkill()
    {
        skill1++;
        SaveSkill(skill1);
    }
    public void costSkill()
    {
        skill1--;
        SaveSkill(skill1);
    }
    public void getDiamond()
    {
        int temp=PlayerPrefs.GetInt("Diamond", Diamond);
        Diamond= temp;
    }
    public void SaveLevel(int levelID)
    {
        int save = IsLevelLucked(levelID)==true?1:0;
        int levelScore=LevelScore(levelID);
        PlayerPrefs.SetInt("Level" + levelID.ToString()+"Locked",save);
        PlayerPrefs.SetInt("Level" + levelID.ToString() + "Score", levelScore);
    }
    public void GetLevel(int levelID)
    {
        int looktemp = PlayerPrefs.GetInt("Level" + levelID.ToString() + "Locked");
        bool look=looktemp==0?false:true;
        int score = PlayerPrefs.GetInt("Level" + levelID.ToString()  + "Score");
        Debug.Log("Level " + levelID + " - Locked: " + look + ", Score: " + score);
    }

}
