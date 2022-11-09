using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource mooSource;
    // Start is called before the first frame update
    void Start()
    {
        mooSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Target"){
            mooSource.Play();
        }
    }
}
