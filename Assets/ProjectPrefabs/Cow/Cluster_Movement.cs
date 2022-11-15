using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cluster_Movement : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Transform Finish;
    private float aggroRange = 10000f;
    private float speed = Random.Range(5f,10f);
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Finish.position)<aggroRange)
        {
           
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(Finish.position);
           
        }else
        {
            navMeshAgent.isStopped = true;
        
        }
        transform.position = Vector3.MoveTowards(transform.position, Finish.transform.position, Time.deltaTime*speed);
        
    }
}
