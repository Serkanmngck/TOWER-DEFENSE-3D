using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioSys : MonoBehaviour
{
    public Text volumeAmount;

    private void Start()
    {
        if(LevelManager.Instance.volume==2)
        {
            LevelManager.Instance.volume = 1;
            AudioListener.volume = LevelManager.Instance.volume;
        }
        else
        {
            AudioListener.volume = LevelManager.Instance.volume;
        }
        volumeAmount.text = ((int)((LevelManager.Instance.volume * 100))).ToString();
    }
    public void setAudio(float value)
    {
        LevelManager.Instance.volume=value;
        AudioListener.volume = LevelManager.Instance.volume;
        volumeAmount.text = ((int)((LevelManager.Instance.volume * 100))).ToString();
    }
}
