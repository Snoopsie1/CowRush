using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource mooSource;

    // Start is called before the first frame update
    private void Start()
    {
        mooSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target") mooSource.Play();
    }
}