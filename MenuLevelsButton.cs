using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevelsButton : MonoBehaviour
{
    [SerializeField] private Canvas menuPanel;
    [SerializeField] private Canvas levels;
    [SerializeField] private Canvas settings;
    private void Start()
    {
        menuPanel.gameObject.SetActive(true);
        levels.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);

    }
    public void openLevel()
    {
        menuPanel.gameObject.SetActive(false);
        levels.gameObject.SetActive(true);

    }
    public void backMenu()
    {
        menuPanel.gameObject.SetActive(true);
        levels.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);

    }
    public void  QuitGame()
    {
        Debug.Log("çýktý");
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif  
    }
    public void getSettings()
    {
        settings.gameObject.SetActive(true);
        levels.gameObject.SetActive(false);
    }
    public void buttonPlay()
    {
        string level = "level" + LevelManager.Instance.currnetlevel().ToString();
        SceneManager.LoadScene(level);
    }
}
