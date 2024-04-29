using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float massValue = 2f;


    private void Reset()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.mass = massValue;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        _rb.mass = massValue;
    }
}
