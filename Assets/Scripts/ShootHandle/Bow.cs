using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    Vector2 direction;
    
    [SerializeField] private InputAction screenPos;

    private Vector2 curMousePos;
    private Vector2 bowPos;
    

    private void OnEnable()
    {
        screenPos.Enable();

        screenPos.performed += OnMousePos;
    }
    private void OnDisable()
    {
        screenPos.Disable();
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
