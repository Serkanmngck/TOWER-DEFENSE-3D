using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ButtonMeneger : MonoBehaviour
{
    public int LevelID;
    public Button button;
    [SerializeField] public Sprite[] images;

    public void Start()
    {
        button = GetComponent<Button>();
        if (LevelManager.Instance.IsLevelLucked(LevelID))
        {
            if ( LevelManager.Instance.LevelScore(LevelID)==0)
            {
                button.image.sprite = images[0];
            }

            else if (LevelManager.Instance.LevelScore(LevelID) == 1)
            {
                button.image.sprite = images[1];
            }

            else if (LevelManager.Instance.LevelScore(LevelID) == 2)
            {
                button.image.sprite = images[2];
            }

            else if (LevelManager.Instance.LevelScore(LevelID) == 3)
            {
                button.image.sprite = images[3];
            }

        }
    }
    public void OpenLevel()
    {
        if(LevelManager.Instance.IsLevelLucked(LevelID))
        {
            SceneManager.LoadScene("Level" + LevelID.ToString());
        }

    }
}
