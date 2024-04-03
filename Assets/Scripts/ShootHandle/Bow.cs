using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Vector2 direction;

    [SerializeField] float force;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;

        direction = mousePos - bowPos;

        faceMouse();
    }


    private void faceMouse()
    {
        transform.right = direction;
    }
}
