using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private static float _initialSpeed = 5f;
    private float _speed = _initialSpeed;
    private float _maxSpeed = 2f;
    private float _gravity = -30f;
    
    private float _jumpForce = 2f;
    private float _jumpTime = 0.33f;
    private float _jumpTimeCounter;
    private bool _isJumping;
    
    
    
    public Transform groundCheck;
    private float _groundDistance = 1.11f;
    public LayerMask groundMask;

    private bool _isJumpDown = false;
    private Vector3 _velocity;
    private bool _isGrounded; 

    void Start()
    {

    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, _groundDistance, groundMask);
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * (x * 2) + transform.forward * (z * 2);
        move = Vector3.ClampMagnitude(move, _maxSpeed);
        
        controller.Move(move * (_speed * Time.deltaTime));
        _velocity.y += _gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isJumping = true;
            _jumpTimeCounter = _jumpTime;
            _velocity = Vector3.up * _jumpForce;
            _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
        }

        if (Input.GetButton("Jump") && _isJumping)
        {
            if (_jumpTimeCounter > 0)
            {
                _velocity = Vector3.up * _jumpForce;
                _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            _isJumping = false;
        }

        controller.Move(_velocity * Time.deltaTime);
    }
}
