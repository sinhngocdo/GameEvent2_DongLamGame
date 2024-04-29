using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput _input;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float limitFlyTop = 0f;
    [SerializeField] private float limitFlyBot = 0f;
 
    private void Awake()
    {
        _input = new CustomInput();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        _input.Enable();
        
        _input.Player.Move.performed += OnPlayerMovePerformed;
        _input.Player.Move.canceled += OnPlayerMoveCancelled;
    }


    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Move.performed -= OnPlayerMovePerformed;
        _input.Player.Move.canceled -= OnPlayerMoveCancelled;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        
        if (transform.position.y >= limitFlyTop)
        {
            transform.position = new Vector3(transform.position.x, limitFlyTop - 0.000001f, transform.position.z);
        }

        else if (transform.position.y <= limitFlyBot)
        {
            transform.position = new Vector3(transform.position.x, limitFlyBot + 0.000001f, transform.position.z);
        }
        else
        {
            Vector2 movement = _movement * moveSpeed  * Time.deltaTime ;
            _rb.MovePosition(_rb.position + movement);
        }
        
        
    }

    private void OnPlayerMovePerformed(InputAction.CallbackContext value)
    {
        _movement = value.ReadValue<Vector2>();
    }

    void OnPlayerMoveCancelled(InputAction.CallbackContext value)
    {
        _movement = Vector2.zero;
    }
}
