using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float positionXLeft;
    [SerializeField] private float positionXRight;
    


    private void Reset()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _transform.position = new Vector3(positionXLeft, _transform.position.y, _transform.position.z);
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            _transform.position = new Vector3(positionXRight, _transform.position.y, _transform.position.z);
            _spriteRenderer.flipX = true;
        }
    }
}
