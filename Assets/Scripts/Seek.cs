using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Seek : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform target;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = target.position;
    }
}
