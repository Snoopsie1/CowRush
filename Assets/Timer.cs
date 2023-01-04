using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{


[Header("Componet")]
public TextMeshProUGUI timerText;

[Header("Time Settings")]
public float currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString();
        
    }
}
