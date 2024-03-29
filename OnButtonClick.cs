using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    private Mweapon mweaponInstance;
    [SerializeField] private int mButtonType;
    [SerializeField] private Type tp;

    public enum Type
    {
        Update,
        Create
    }

    private void Awake()
    {
        mweaponInstance = Mweapon.Instance;
    }


    public void OnButtonclick()
    {
        Debug.Log("buraya girdi");
        if (tp == Type.Update)
        {
            mweaponInstance.weaponUpdate(mButtonType);
        }
        else if (tp == Type.Create)
        {
            Debug.Log("buraya girdi");
            mweaponInstance.CreateObject(mButtonType);
        }
    }

    public void pauseButton()
    {
        UIManager.Instance.pauseCanvas.enabled = true;
        UIManager.Instance.settingsCanvas.enabled = false;
        Time.timeScale = 0f;
    }
    public void unPauseButton()
    {
        Time.timeScale = 1f;
        UIManager.Instance.pauseCanvas.enabled = false;
    }
    public void settingsButton()
    {
        UIManager.Instance.pauseCanvas.enabled = false;
        UIManager.Instance.settingsCanvas.enabled = true;  
    }

}