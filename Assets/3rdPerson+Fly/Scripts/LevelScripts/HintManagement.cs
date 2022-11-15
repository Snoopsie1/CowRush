using UnityEngine;

// This class is created for the example scene. There is no support for this script.
public class HintManagement : MonoBehaviour
{
    public string message = "";
    public string message2 = "";
    public KeyCode changeMessageKey;

    private ControlsTutorial manager;

    private GameObject player;
    private bool used;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControlsTutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !used)
        {
            manager.SetShowMsg(true);
            manager.SetMessage(message);
            used = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            manager.SetShowMsg(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (message2 != "" && other.gameObject == player && Input.GetKeyDown(changeMessageKey))
            manager.SetMessage(message2);
    }
}