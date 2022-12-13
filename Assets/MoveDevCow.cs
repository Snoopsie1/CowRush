using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDevCow : MonoBehaviour
{
    public GameObject Cow;
    private Vector3 target;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Cow = GameObject.FindWithTag("Cow");
        target = GameObject.FindWithTag("Target").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Cow.transform.position = Vector3.MoveTowards(Cow.transform.position, target, Time.deltaTime * speed);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.transform.SetParent(transform);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // other.transform.SetParent(null);
        }
    }
    */
}
