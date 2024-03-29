using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public Canvas buyWeapons;
    public Canvas weaponUpdateType11;
    public Canvas win;
    [SerializeField]public Canvas settingsCanvas;
    [SerializeField]public Canvas pauseCanvas;
    [SerializeField]public Image[] winsImage;


    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("UIManagerSingleton");
                    _instance = singletonObject.AddComponent<UIManager>();
                }
            }
            return _instance;
        }
    }
    private void Start()
    {
        buyWeapons.enabled = false;
        weaponUpdateType11.enabled = false;
        pauseCanvas.enabled = false;
        win.enabled= false;
        settingsCanvas.enabled = false;

        foreach (Image image in winsImage)
        {
            image.enabled = false;
        }

    }


}
