using UnityEngine;
using UnityEngine.AI;

public class Movements : MonoBehaviour
{
    private GameObject Finish;
    private readonly float aggroRange = 80000f;
    private NavMeshAgent navMeshAgent;
    
    private GameObject Cow;
    private float speed;

    // Start is called before the first frame update
    private void Start()
    {
        Cow = GameObject.FindWithTag("Cow");
        Finish = GameObject.FindWithTag("Finish");
        navMeshAgent = GetComponent<NavMeshAgent>();
        speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, Finish.transform.position) < aggroRange)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(Finish.transform.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
        }
        
        Debug.Log(Finish.transform.position);
        if (gameObject.transform.position.z >= Finish.transform.position.z) {
            Destroy(this.gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Finish.transform.position.x, Finish.transform.position.y, Finish.transform.position.z + 60), Time.deltaTime * speed);
    }
}