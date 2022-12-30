using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
[Header ("Component")]
public TextMeshProUGUI timerText;

[Header("Timer Settings")]
public float currentTime;

private int minutes;
private int seconds;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(currentTime / 60F);
        seconds = Mathf.FloorToInt(currentTime - minutes * 60);

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        //timerText.text = string.Format("{0:0.00}", currentTime.ToString());
    }
}
