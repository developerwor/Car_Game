using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshagent : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Transform[] destination_position;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        int destnation_random = Random.Range(0,4);
        int agentmove = Random.Range(0,250);

        navMeshAgent.destination = destination_position[destnation_random].position;
        navMeshAgent.SetDestination(navMeshAgent.destination);

        navMeshAgent.speed += 20f;

        if (agentmove == 0)
        {
            navMeshAgent.isStopped = true;
            Debug.Log("정지 구간");
        }
        else
        {
            navMeshAgent.isStopped = false;
            Debug.Log("플레이 구간");
        }

    }
}
