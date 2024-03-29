using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Manager : MonoBehaviour
{
    public static Map_Manager instance;
    public Transform tower;
    private void Awake()
    {
        instance = this;
    }

}
