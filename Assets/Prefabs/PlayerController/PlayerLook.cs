using System;
using UnityEngine;

/**
 * Brackeys but edited for our use :)
 * https://www.youtube.com/watch?v=_QajrabyTJc
 */
public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 500f;
    public Transform playerBody;
    private float xRotation;


    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}