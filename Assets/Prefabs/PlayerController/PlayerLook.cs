using System;
using UnityEngine;

/**
 * Brackeys but edited for our use :)
 * https://www.youtube.com/watch?v=_QajrabyTJc
 */
public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public Transform playerBody;
    private float xRotation;
    private float clampedRotation;
    private Vector2 rotation;

    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private Vector2 GetMouse()
    {
        Vector2 mouse = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
        );
        return mouse;
    }
}