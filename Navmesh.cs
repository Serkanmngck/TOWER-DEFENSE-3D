using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{

    private NavMeshAgent agent;
    
  

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {

        agent.SetDestination(Map_Manager.instance.tower.position);
    }

}
