using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;
public class finish_script : MonoBehaviour
{
    public GameObject player;
    public GameObject finish;
    public GameObject complete;
    public TextMeshProUGUI finishTime;
    public TextMeshProUGUI time;
    [SerializeField] public GameObject bronzeMedal;
    [SerializeField] public GameObject silverMedal;
    [SerializeField] public GameObject goldMedal;

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
            complete.SetActive(true);
            finishTime.text = "Time: " + time.text;
            
            string[] words = time.text.Split(':');
            int miniutes = Convert.ToInt32(words[0]);
            int secounds = Convert.ToInt32(words[1]);

            int finalTime = (miniutes * 60) + secounds;
            Debug.Log("hej");
            Debug.Log(finalTime);
            Debug.Log(finalTime.GetType());
            
            if (finalTime < 10)
            {
                goldMedal.SetActive(true);
                Debug.Log("det blev gold");
            }
            else if (finalTime >= 10 && finalTime <= 20)
            {
                silverMedal.SetActive(true);
                Debug.Log("det blev silver");
            }
            else if (finalTime > 20)
            {
                bronzeMedal.SetActive(true);
                Debug.Log("det blev bronze");
            }

            Time.timeScale = 0;
        }
    }
}
