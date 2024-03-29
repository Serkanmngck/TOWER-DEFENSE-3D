using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour
{
    public GameObject[] mweapons; // weapons dizisi burada tanýmlanýyor

    public GameObject GetWeaponObject(int type)
    {
        if (type >= 0 && type < mweapons.Length && mweapons[type] != null)
        {
            return mweapons[type];
        }
        else
        {
            UnityEngine.Debug.LogError("Geçersiz silah tipi!");
            return null;
        }
    }
}
