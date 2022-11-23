using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
       if (player.transform.position.y <= 7)
       {
            player.transform.position = new Vector3(125, 31, 91);
       }
    }
}
