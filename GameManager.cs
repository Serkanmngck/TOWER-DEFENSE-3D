using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] public int castleHP = 20;
    [SerializeField] public int totalGold = 0;
    [SerializeField] public int currentSpawnWawes=0;
    [SerializeField] public int maxSpawnWawes;
    public bool waweControl=false;
    public bool succesfull=false;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManagerSingleton");
                    _instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public void damageCastle()
    {
        castleHP--;

    }
    public void TotalGold(int goldOnDeath)
    {
        totalGold += goldOnDeath;
    }
    private void Update()
    {
        if(waweControl)
        {
            StartCoroutine(onesecond());
            
        }
    }
    IEnumerator onesecond()
    {
        waweControl = false;
        yield return new WaitForSeconds(1f);
        currentSpawnWawes++;

    }

    public void skillkontrol()
    {
        int skill = int.Parse(LevelManager.Instance.ShowSkill());
        if(skill>0)
        {


            LevelManager.Instance.costSkill();
            LevelManager.Instance.SaveSkill(skill);
            LevelManager.Instance.getSkill();
        }
    }
}
