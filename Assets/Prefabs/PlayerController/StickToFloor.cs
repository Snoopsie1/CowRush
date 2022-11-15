using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cow")
        {
            transform.parent.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Cow")
        {
            transform.parent.SetParent(null);
        }
    }
}
