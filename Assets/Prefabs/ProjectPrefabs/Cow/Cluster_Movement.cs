using UnityEngine;
using UnityEngine.AI;

public class Cluster_Movement : MonoBehaviour
{
    public Transform Finish;
    private readonly float aggroRange = 10000f;
    private NavMeshAgent navMeshAgent;
    private float speed = Random.Range(5f, 10f);

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, Finish.position) < aggroRange)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(Finish.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, Finish.transform.position, Time.deltaTime * speed);
    }
}