using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_script : MonoBehaviour
{
    public GameObject player;
    public GameObject finish;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
        finish = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= finish.transform.position.z)
       {
            SceneManager.LoadScene("worldSelector");
       }
    }
}
