using System;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly float _initialSpeed = 5f;
    public CharacterController controller;
    public GameObject Player;

    private Transform platform;
    private bool isOnPlatform;
    private Vector3 lastPlatformPos;

    public Transform groundCheck;
    public LayerMask groundMask;
    private readonly float _gravity = -30f;
    private readonly float _groundDistance = 0.11f;
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
        
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * (x * 2) + transform.forward * (z * 2);
        move = Vector3.ClampMagnitude(move, _maxSpeed);

        controller.Move(move * (_speed * Time.deltaTime));
        _velocity.y += _gravity * Time.deltaTime;
        
        Debug.Log("yVel: " + _velocity.y);

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
        
        if (isOnPlatform)
        {
            Vector3 deltaPosition = platform.position - lastPlatformPos;
            transform.position = transform.position + deltaPosition;
            lastPlatformPos = platform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            platform = other.gameObject.GetComponent<Transform>();
            lastPlatformPos = platform.position;
            isOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            isOnPlatform = false;
            platform = null;
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cow"))
        {
            transform.SetParent(other.transform);
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cow"))
        {
            transform.SetParent(null);
        }
    }
    */
}