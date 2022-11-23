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

    void OnCollisionEnter(Collision collision)
    {
        Console.WriteLine(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hej m,or");
            collision.transform.SetParent(transform);
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
