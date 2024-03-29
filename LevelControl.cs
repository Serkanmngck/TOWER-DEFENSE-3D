using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelControl : MonoBehaviour
{
    
    public bool successfull=false;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    private void Start()
    {

    }
    void Update()
    {
        if (GameManager.Instance.castleHP<=0)
        {
           
            UIManager.Instance.win.enabled = true;
            UIManager.Instance.winsImage[0].enabled = true;
            Time.timeScale = 0;

        }
        if(GameManager.Instance.currentSpawnWawes==GameManager.Instance.maxSpawnWawes&&GameManager.Instance.succesfull)
        {
            
            //LevelManager.Instance.addDiamond(10);
            
            LevelManager.Instance.UpdateLevelLocked(levelnextfind(),true);
            successfull = true;
            UIManager.Instance.win.enabled = true;
            if(GameManager.Instance.castleHP==20)
            {
                UIManager.Instance.winsImage[3].enabled = true;
                LevelManager.Instance.UpdateLevelscore(levelcurrentfind(), 3);
            }
            else if(GameManager.Instance.castleHP<20&& GameManager.Instance.castleHP >= 10)
            {
                UIManager.Instance.winsImage[2].enabled = true;
                LevelManager.Instance.UpdateLevelscore(levelcurrentfind(), 2);
            }
            else if (GameManager.Instance.castleHP < 10 && GameManager.Instance.castleHP > 0)
            {
                UIManager.Instance.winsImage[1].enabled = true;
                LevelManager.Instance.UpdateLevelscore(levelcurrentfind(), 1);
            }
                Time.timeScale = 0;
        }

        
    }

    public void retryOrNext()
    {
        if(successfull) { levelNext(); }
        else {levelagain();  }
    }
    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
    public void levelagain()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneName);

    }
    public void levelNext()
    {
       string currentSceneName = SceneManager.GetActiveScene().name;
       int nextLevelNumber = levelnextfind();
       string nextSceneName = currentSceneName.Substring(0, currentSceneName.Length - 1) + nextLevelNumber;
       Time.timeScale = 1f;
       SceneManager.LoadScene(nextSceneName); 

    }
    public int levelcurrentfind()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string levelNumberString = new string(currentSceneName.Where(char.IsDigit).ToArray());
        if (int.TryParse(levelNumberString, out int currentLevelNumber))
        {
            return currentLevelNumber;
        }
        return -1;
    }
    public int levelnextfind()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string levelNumberString = new string(currentSceneName.Where(char.IsDigit).ToArray());
        if (int.TryParse(levelNumberString, out int currentLevelNumber))
        {
            currentLevelNumber += 1;
            return currentLevelNumber;
        }
        return -1;
    }




}
