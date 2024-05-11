using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    Vector2 direction;
    
    private CustomInput screenPos;

    private Vector2 curMousePos;
    private Vector2 bowPos;

    private void Awake()
    {
        screenPos = new CustomInput();
    }

    private void OnEnable()
    {
        screenPos.Enable();

        screenPos.Player.MousePosition.performed += OnMousePos;
    }
    private void OnDisable()
    {
        screenPos.Disable();
        screenPos.Player.MousePosition.performed -= OnMousePos;
    }

    private void OnMousePos(InputAction.CallbackContext context)
    {
        curMousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) ;
    }



    // Update is called once per frame
    void Update()
    {
        bowPos = transform.position;

        direction = curMousePos - bowPos;

        faceMouse();
    }


    private void faceMouse()
    {
        transform.right = direction;
    }
}