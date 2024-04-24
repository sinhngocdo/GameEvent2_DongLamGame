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

    private void Awake()
    {
        _input = new CustomInput();
        _rb = GetComponent<Rigidbody2D>();
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
        _rb.velocity = _movement * moveSpeed  * Time.deltaTime ;
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
