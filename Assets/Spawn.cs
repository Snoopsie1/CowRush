
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
  
   public GameObject Cow;
   public GameObject Start_Platform;
   public float respownTime = 4.0f; 

    // Start is called before the first frame update
    void Start()
    {
          //number of Objects
        //int randomIndex = Random.Range(5,15);
       // spwn point
        //Vector3 randomSpawnPosition = new Vector3(Random.Range(0,10),5,Random.Range(-10,11));

        //Instantiate(Cow,randomSpawnPosition, Quaternion.identity);
        StartCoroutine(spawningCows());
    }
    private void spwanCow(){
        GameObject a = Instantiate(Cow) as GameObject;
        a.transform.position = new Vector3(Start_Platform.transform.position.x - 20, Start_Platform.transform.position.y - 10, Start_Platform.transform.position.z - 20);
    }

    // Update is called once per frame
    IEnumerator spawningCows(){
        while (true){
            yield return new WaitForSeconds(respownTime);
            spwanCow();
        }
        

    }
}