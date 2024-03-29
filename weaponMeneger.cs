using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    public string levelName;
    public int damage;
    public float attackSpeed;
    public float attacRadius;
    public int weaponHealth;
    public int cost;
    public int gameObjectType;
    public Bullet bullet;
    private List<weaponManager> weaponType1;
    private List<weaponManager> weaponType2;
    private List<weaponManager> weaponType3;
    private List<weaponManager> weaponType4;
    private static weaponManager _instance;

    public static weaponManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<weaponManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("WeaponManager");
                    _instance = singletonObject.AddComponent<weaponManager>();
                }
            }

            return _instance;
        }
    }
    private weaponManager(string levelName = null, int damage = 0, float attackSpeed = 0, float attacRadius = 0, int weaponHealth = 0, int cost = 0, int gameObjectType = 0)
    {
        this.cost = cost;
        this.gameObjectType = gameObjectType;
    }

    private void Awake()
    {

        weaponType1 = new List<weaponManager>();
        weaponType2 = new List<weaponManager>();
        weaponType3 = new List<weaponManager>();
        weaponType4 = new List<weaponManager>();


        weaponType1.Add(new weaponManager("levl1", 1, 1, 3, 10, 100, 0));
        weaponType1.Add(new weaponManager("level2", 1, 1, 3, 10, 110, 1));
        weaponType1.Add(new weaponManager("level3", 1, 1, 3, 10, 200, 2));

        weaponType2.Add(new weaponManager("levl1", 1, 1, 3, 10, 100, 3));
        weaponType2.Add(new weaponManager("level2", 1, 1, 3, 10, 110, 4));
        weaponType2.Add(new weaponManager("level3", 1, 1, 3, 10, 200, 5));

        weaponType3.Add(new weaponManager("levl1", 1, 1, 3, 10, 200, 6));
        weaponType3.Add(new weaponManager("level2", 1, 1, 3, 10, 280, 7));
        weaponType3.Add(new weaponManager("level3", 1, 1, 3, 10, 400, 8));

        weaponType4.Add(new weaponManager("levl1", 1, 1, 3, 10, 300, 9));
        weaponType4.Add(new weaponManager("level2", 1, 1, 3, 10, 420, 10));
        weaponType4.Add(new weaponManager("level3", 1, 1, 3, 10, 600
            , 11));

    }
    public List<weaponManager> GetWeaponType1List()
    {
        return weaponType1;
    }
    public List<weaponManager> GetWeaponType2List()
    {
        return weaponType2;
    }
    public List<weaponManager> GetWeaponType3List()
    {
        return weaponType3;
    }
    public List<weaponManager> GetWeaponType4List()
    {
        return weaponType4;
    }
    public List<int> priceList()
    {
         List<int> price = new List<int>
        {
            weaponType1[0].cost, weaponType1[1].cost, weaponType1[2].cost,
            weaponType2[0].cost, weaponType2[1].cost, weaponType2[2].cost,
            weaponType3[0].cost, weaponType3[1].cost, weaponType3[2].cost,
             weaponType4[0].cost, weaponType4[1].cost, weaponType4[2].cost
        };

        return price;
    }
    public int Cost
    {
        get { return cost; }
    }

}