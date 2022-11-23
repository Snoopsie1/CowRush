using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly float _initialSpeed = 5f;
    public CharacterController controller;

    public Transform groundCheck;
    public LayerMask groundMask;
    private readonly float _gravity = -30f;
    private readonly float _groundDistance = 1.11f;
    private bool _isGrounded;

    private bool _isJumpDown = false;
    private bool _isJumping;

    private readonly float _jumpForce = 2f;
    private readonly float _jumpTime = 0.33f;
    private float _jumpTimeCounter;
    private readonly float _maxSpeed = 2f;
    private readonly float _speed = _initialSpeed;
    private Vector3 _velocity;
    
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, _groundDistance, groundMask);


        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * (x * 2) + transform.forward * (z * 2);
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

        if (Input.GetButtonUp("Jump")) _isJumping = false;
        controller.Move(_velocity * Time.deltaTime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cow")
        {
            Debug.Log("Stuck to cow");
            transform.SetParent(collision.transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Cow")
        {
            Debug.Log("Release from cow");
            transform.SetParent(null);
        }
    }
}