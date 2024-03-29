using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{

    [SerializeField] private UItexet text;
    private Text tWave;
    private Text tGold;
    private Text tHearth;
    private Text wprice;
    private Text tDiamond;
    private Text tSkill1;
    private string price;
    private weaponManager winstance;
    private List<int> prices;
    static public int uiType;
    /*public static UIText Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }*/
    public enum UItexet
    {
        wave,
        hearth,
        gold,
        weaponPriceType11,
        weaponPriceType21,
        weaponPriceType31,
        weaponPriceType41,
        sell,
        update,
        Diamond,
        Skill1

    }


    private void Start()
    {
        
        tWave = GetComponent<Text>();
        tGold = GetComponent<Text>();
        tHearth = GetComponent<Text>();
        tSkill1 = GetComponent<Text>();
        tDiamond = GetComponent<Text>();
        prices = new List<int>();
        prices = weaponManager.Instance.priceList();
        wprice = GetComponent<Text>();
        
    }

    private void Update()
    { 
        if (text == UItexet.hearth)
        {
            tHearth.text = GameManager.Instance.castleHP.ToString();
        }
        else if (text == UItexet.gold)
        {
            tGold.text = GameManager.Instance.totalGold.ToString();
        }
        else if (text == UItexet.wave)
        {
            string temp = GameManager.Instance.currentSpawnWawes.ToString() + "/" + GameManager.Instance.maxSpawnWawes.ToString();
            tWave.text = temp;
        }
        else if (text == UItexet.Diamond)
        {
            tDiamond.text = LevelManager.Instance.ShowDiamond();
        }
        else if (text == UItexet.Skill1)
        {
            string temp = LevelManager.Instance.ShowSkill();
            tSkill1.text = temp;
        }
        else { weaponPrice(); }
    }
    public void UiType(int ui)
    {
        uiType = ui;
        Debug.Log("uii:"+ui);

    }
    public void weaponPrice()
    {
        if (UItexet.weaponPriceType11 == text)
        {
            price = prices[0].ToString();
        }

        else if (UItexet.weaponPriceType21 == text)
        {
            price = prices[3].ToString();
        }

        else if (UItexet.weaponPriceType31 == text)
        {
            price = prices[6].ToString();
        }

        else if (UItexet.weaponPriceType41 == text)
        {
            price = prices[9].ToString();
        }

        else if (UItexet.update == text)
        {
            
            if(uiType == 0) { price = ""; }
            else if (uiType == 11)
            {
                price = prices[1].ToString();
            }

            else if (uiType == 12)
            {
                price = prices[2].ToString();
            }

            else if (uiType == 13)
            {
                price = ("Max Level");
            }


            else if (uiType == 21)
            {
                price = prices[4].ToString();
            }


            else if (uiType == 22)
            {
                price = prices[5].ToString();
            }


            else if (uiType == 23)
            {
                price = ("Max Level");
            }


            else if (uiType == 31)
            {
                price = prices[7].ToString();
            }


            else if (uiType == 32)
            {
                price = prices[8].ToString();
            }


            else if (uiType == 33)
            {
                price = ("Max Level");
            }


            else if (uiType == 41)
            {
                price = prices[10].ToString();
            }

            else if (uiType == 42)
            {
                price = prices[11].ToString();
            }


            else if (uiType == 43)
            {
                price = ("Max Level");
            }
        }

         if (UItexet.sell == text)
        {
            if (uiType == 0) { price = ""; }

            else if (uiType == 11)
            {
                price = ((int)(prices[0] * 0.7)).ToString();
            }

            else if (uiType == 12)
            {
                price = ((int)(prices[1] * 1.5)).ToString();
            }

            else if (uiType == 13)
            {
                price = ((int)(prices[2] * 1.5)).ToString();
            }


            else if (uiType == 21)
            {
                price = ((int)(prices[3] * 0.7)).ToString();
            }


            else if (uiType == 22)
            {
                price = ((int)(prices[4] * 1.5)).ToString();
            }


            else if (uiType == 23)
            {
                price = ((int)(prices[5] * 1.5)).ToString();
            }


            else if (uiType == 31)
            {
                price = ((int)(prices[6] * 0.7)).ToString();
            }


            else if (uiType == 32)
            {
                price = ((int)(prices[7] * 1.2)).ToString();
            }


            else if (uiType == 33)
            {
                price = ((int)(prices[8] * 1.5)).ToString();
            }


            else if (uiType == 41)
            {
                price = ((int)(prices[9] * 0.7)).ToString();
            }

            else if (uiType == 42)
            {
                price = ((int)(prices[10] * 1.2)).ToString();
            }


            else if (uiType == 43)
            {
                price = ((int)(prices[11] * 1.2)).ToString();
            }
        }
        wprice.text = price;
     }
}

    
