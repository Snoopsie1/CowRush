using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Cow;
    public GameObject Start_Platform;
    private System.Random rnd;
    // Start is called before the first frame update
    private void Start()
    {
        //number of Objects
        //int randomIndex = Random.Range(5,15);
        // spwn point
        //Vector3 randomSpawnPosition = new Vector3(Random.Range(0,10),5,Random.Range(-10,11));

        //Instantiate(Cow,randomSpawnPosition, Quaternion.identity);
        StartCoroutine(spawningCows());
        rnd = new System.Random();
    }

    private void spwanCow()
    {
        var a = Instantiate(Cow);
        a.transform.eulerAngles = new Vector3(0,0,0);
        a.transform.position = new Vector3((Start_Platform.transform.position.x + 50)- rnd.Next(1,10) * 10,
            Start_Platform.transform.position.y - 10, Start_Platform.transform.position.z - 20);
    }

    // Update is called once per frame
    private IEnumerator spawningCows()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            spwanCow();
        }
    }
}