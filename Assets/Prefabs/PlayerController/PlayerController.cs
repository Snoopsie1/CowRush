using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private float _speed = 5f;
    private float _gravity = -15f;
    private float _jumpHeight = 3f;

    private float _allowJumpDistance = 1.2f;
    private Vector3 _velocity;

    private bool _isGrounded = true;


    void Start()
    {

    }

    void Update()
    {
        CheckGrounded();
        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move = Vector3.ClampMagnitude(move, 1f);
        controller.Move(move * _speed * Time.deltaTime);
        _velocity.y += _gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        controller.Move(_velocity * Time.deltaTime);
    }

    void CheckGrounded()
    {
        Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hitGround);
        float distanceToGround = hitGround.distance;
        if (hitGround.collider == null)
        {
            _isGrounded = false;
        }
        else
        {
            _isGrounded = distanceToGround <= _allowJumpDistance;
        }

    }
}
