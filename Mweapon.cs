using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEngine.Rendering.DebugUI;

public class Mweapon : MonoBehaviour
{

    public bool simulasyonModu = true;
    private int updateObjectRef;
    private UIManager UIinstance;
    [SerializeField] private Transform wTransform;
    [SerializeField] private GameObject platformPrefab;
    private weaponManager winstance;
    List<weaponManager> weaponType1List;
    List<weaponManager> weaponType2List;
    List<weaponManager> weaponType3List;
    List<weaponManager> weaponType4List;
    public GameObject[] mweapons;
    public GameObject tempObject;
    GameObject hitObject = null;
    private bool touchObject=true;
    private static Mweapon _instance;
    private List<int> prices;
    private UIText ui;
    RaycastHit hit;

    public static Mweapon Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Mweapon>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("MweaponSingleton");
                    _instance = singletonObject.AddComponent<Mweapon>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }
    private void Start()
    {
        UIinstance = UIManager.Instance;
        winstance = weaponManager.Instance;
        weaponType1List = winstance.GetWeaponType1List();
        weaponType2List = winstance.GetWeaponType2List();
        weaponType3List = winstance.GetWeaponType3List();
        weaponType4List = winstance.GetWeaponType4List();
        prices = winstance.priceList();
        ui = FindObjectOfType<UIText>();


    }
    void Update()
    {
        if (simulasyonModu)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePozisyon = Input.mousePosition;
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }

                if (touchObject)
                {
                    HandleTouch(mousePozisyon);
                }

            }
        }
       /* else if
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 dokunmaPozisyon = touch.position;
                    if (touchObject)
                    { 
                        HandleTouch(dokunmaPozisyon); 
                    }
                }
            }
        }*/
    }

    public void weaponUpdate(int wno)
    {
        List<weaponManager> updateList = null;
        GameObject updateObject = null;


        switch (wno)
        {
            case 0:
                if (updateObjectRef == 11)
                {
                    updateList = weaponType1List;
                    int cost = updateList[0].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold +=(int) (cost*0.7f);
                    UIinstance.weaponUpdateType11.enabled = false;
                   
                }
                else if (updateObjectRef == 12)
                {
                    updateList = weaponType1List;
                    int cost = updateList[1].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 1.5f);
                    UIinstance.weaponUpdateType11.enabled = false;
                }
                else if (updateObjectRef == 13)
                {
                    updateList = weaponType1List;
                    int cost = updateList[2].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 1.5f);
                    UIinstance.weaponUpdateType11.enabled = false;
                }

                else if (updateObjectRef == 21)
                {
                    updateList = weaponType2List;
                    int cost = updateList[0].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 0.7f);
                    UIinstance.weaponUpdateType11.enabled = false;

                }
                else if (updateObjectRef == 22)
                {
                    updateList = weaponType2List;
                    int cost = updateList[1].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 1.5f);
                    UIinstance.weaponUpdateType11.enabled = false;


                }
                else if (updateObjectRef == 23)
                {
                    updateList = weaponType2List;
                    int cost = updateList[2].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 1.5f);
                    UIinstance.weaponUpdateType11.enabled = false;
                }

                else if (updateObjectRef == 31)
                {
                    updateList = weaponType3List;
                    int cost = updateList[0].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 0.7f);
                    UIinstance.weaponUpdateType11.enabled = false;

                }
                else if (updateObjectRef == 32)
                {
                    updateList = weaponType3List;
                    int cost = updateList[1].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 1.2f);
                    UIinstance.weaponUpdateType11.enabled = false;


                }
                else if (updateObjectRef == 33)
                {
                    updateList = weaponType3List;
                    int cost = updateList[2].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 1.5f);
                    UIinstance.weaponUpdateType11.enabled = false;
                }


                else if (updateObjectRef == 41)
                {
                    updateList = weaponType4List;
                    int cost = updateList[0].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 0.7f);
                    UIinstance.weaponUpdateType11.enabled = false;

                }
                else if (updateObjectRef == 42)
                {
                    updateList = weaponType4List;
                    int cost = updateList[1].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 1.2f);
                    UIinstance.weaponUpdateType11.enabled = false;


                }
                else if (updateObjectRef == 43)
                {
                    updateList = weaponType4List;
                    int cost = updateList[2].cost;
                    Instantiate(platformPrefab, hitObject.transform.position, Quaternion.identity);
                    Destroy(hitObject);
                    GameManager.Instance.totalGold += (int)(cost * 1.2f);
                    UIinstance.weaponUpdateType11.enabled = false;
                }
                break;

            case 1:

                if (updateObjectRef == 11)
                {
                    updateList = weaponType1List;
                    int cost = updateList[1].cost;
                    updateObject = mweapons[updateList[1].gameObjectType];
                    if (GameManager.Instance.totalGold >= cost)
                    {
                        Instantiate(updateObject, hitObject.transform.position, Quaternion.identity);
                        Destroy(hitObject);
                        GameManager.Instance.totalGold -= cost;
                        UIinstance.weaponUpdateType11.enabled = false;
                    }

                }
                else if (updateObjectRef == 12)
                {
                    updateList = weaponType1List;
                    int cost = updateList[2].cost;
                    updateObject = mweapons[updateList[2].gameObjectType];
                    if (GameManager.Instance.totalGold >= cost)
                    {
                        Instantiate(updateObject, hitObject.transform.position, Quaternion.identity);
                        Destroy(hitObject);
                        GameManager.Instance.totalGold -= cost;
                    }


                }
                else if (updateObjectRef == 13)
                {
                    Debug.Log("son seviye");
                }

                else if (updateObjectRef == 21)
                {
                    updateList = weaponType2List;
                    int cost = updateList[1].cost;
                    updateObject = mweapons[updateList[1].gameObjectType];
                    if (GameManager.Instance.totalGold >= cost)
                    {
                        Instantiate(updateObject, hitObject.transform.position, Quaternion.identity);
                        Destroy(hitObject);
                        GameManager.Instance.totalGold -= cost;
                    }

                }
                else if (updateObjectRef == 22)
                {
                    updateList = weaponType2List;
                    int cost = updateList[2].cost;
                    updateObject = mweapons[updateList[2].gameObjectType];
                    if (GameManager.Instance.totalGold >= cost)
                    {
                        Instantiate(updateObject, hitObject.transform.position, Quaternion.identity);
                        Destroy(hitObject);
                        GameManager.Instance.totalGold -= cost;
                    }


                }
                else if (updateObjectRef == 23)
                {
                    Debug.Log("son seviye");
                }

                else if (updateObjectRef == 31)
                {
                    updateList = weaponType3List;
                    int cost = updateList[1].cost;
                    updateObject = mweapons[updateList[1].gameObjectType];
                    if (GameManager.Instance.totalGold >= cost)
                    {
                        Instantiate(updateObject, hitObject.transform.position, Quaternion.identity);
                        Destroy(hitObject);
                        GameManager.Instance.totalGold -= cost;
                    }

                }
                else if (updateObjectRef == 32)
                {
                    updateList = weaponType3List;
                    int cost = updateList[2].cost;
                    updateObject = mweapons[updateList[2].gameObjectType];
                    if (GameManager.Instance.totalGold >= cost)
                    {
                        Instantiate(updateObject, hitObject.transform.position, Quaternion.identity);
                        Destroy(hitObject);
                        GameManager.Instance.totalGold -= cost;
                    }


                }
                else if (updateObjectRef == 33)
                {
                    Debug.Log("son seviye");
                }


                else if (updateObjectRef == 41)
                {
                    updateList = weaponType4List;
                    int cost = updateList[1].cost;
                    updateObject = mweapons[updateList[1].gameObjectType];
                    if (GameManager.Instance.totalGold >= cost)
                    {
                        Instantiate(updateObject, hitObject.transform.position, Quaternion.identity);
                        Destroy(hitObject);
                        GameManager.Instance.totalGold -= cost;
                    }

                }
                else if (updateObjectRef == 42)
                {
                    updateList = weaponType4List;
                    int cost = updateList[2].cost;
                    updateObject = mweapons[updateList[2].gameObjectType];
                    if (GameManager.Instance.totalGold >= cost)
                    {
                        Instantiate(updateObject, hitObject.transform.position, Quaternion.identity);
                        Destroy(hitObject);
                        GameManager.Instance.totalGold -= cost;
                    }


                }
                else if (updateObjectRef == 43)
                {
                    Debug.Log("son seviye");
                }
                break;
            default:
                Debug.Log("Geçersiz caslte deðeri.");
                break;


        }
        UIinstance.weaponUpdateType11.enabled = false;
        StartCoroutine(WaitAndPrint());
    }
    void HandleTouch(Vector3 dokunmaPozisyon)
    {
        Ray ray = Camera.main.ScreenPointToRay(dokunmaPozisyon);

        int layerMask = 1 << LayerMask.NameToLayer("touchObject");

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 22f);

        

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
           
            hitObject = hit.collider.gameObject;
            Debug.Log("Iþýn çarptý: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "weaponType1.1")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 11;
                UIManager.Instance.buyWeapons.enabled = false;

            }
            else if (hit.collider.gameObject.tag == "weaponType1.2")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 12;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType1.3")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 13;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType2.1")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 21;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType2.2")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 22;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType2.3")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 23;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType3.1")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 31;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType3.2")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 32;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType3.3")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 33;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType4.1")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 41;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType4.2")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 42;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "weaponType4.3")
            {
                UIinstance.weaponUpdateType11.enabled = true;
                updateObjectRef = 43;
                UIManager.Instance.buyWeapons.enabled = false;
            }
            else if (hit.collider.gameObject.tag == "BuyingWeapon")
            {
                Debug.Log("var");
                UIinstance.buyWeapons.enabled = true;
                UIManager.Instance.weaponUpdateType11.enabled = false;

            }
            else { Debug.Log("hatavarss"); }
            ui.UiType(updateObjectRef);
        }
        else
        {
            Debug.Log("Iþýn hiçbir nesneye çarpmadý.");
            UIManager.Instance.weaponUpdateType11.enabled = false;
            UIManager.Instance.buyWeapons.enabled = false;

        }
    }


    public void CreateObject(int caslte)
    {
        Debug.Log("buraya girdi");
        List<weaponManager> list = null;

        switch (caslte)
        {
            case 0:
                list = weaponType1List;
                break;
            case 1:
                list = weaponType2List;
                break;
            case 2:
                list = weaponType3List;
                break;
            case 3:
                list = weaponType4List;
                break;
            default:
                Debug.Log("Geçersiz caslte deðeri.");
                break;


        }

        weaponManager weaponFromType = list[0];
        GameObject weaponObject = mweapons[weaponFromType.gameObjectType];
        int costFromType = weaponFromType.cost;
        if (GameManager.Instance.totalGold >= costFromType)
        {
            Instantiate(weaponObject, hitObject.transform.position, Quaternion.identity);
            Destroy(hitObject);
            GameManager.Instance.totalGold -= costFromType;
            UIinstance.buyWeapons.enabled = false;
        }
        StartCoroutine(WaitAndPrint());
    }
    IEnumerator WaitAndPrint()
    {
        Debug.Log("bekliyr");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("bekledi");
        touchObject = true;

    }
}
