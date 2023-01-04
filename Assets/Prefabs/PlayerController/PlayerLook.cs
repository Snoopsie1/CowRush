using System;
using UnityEngine;

/**
 * Brackeys but edited for our use :)
 * https://www.youtube.com/watch?v=_QajrabyTJc
 */
public class PlayerLook : MonoBehaviour
{
    [SerializeField] public float sensitivity;
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
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

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