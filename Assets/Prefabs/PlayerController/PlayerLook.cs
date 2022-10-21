using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


/**
 * Brackeys but edited for our use :)
 * https://www.youtube.com/watch?v=_QajrabyTJc
 */
public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 500f;
    public Transform playerBody;
    private float xRotation = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
