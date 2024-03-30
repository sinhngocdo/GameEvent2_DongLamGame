using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Vector2 direction;

    [SerializeField] float force;

    [SerializeField] GameObject pointPrefab;
    GameObject[] points;

    [SerializeField] int numberPoints;


    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberPoints];
        for (int i = 0; i < numberPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;

        direction = mousePos - bowPos;

        faceMouse();

        for (int i = 0; i < numberPoints; i++)
        {
            points[i].transform.position = PointPosition(i * 0.1f);
        }
    }

    private Vector3 PointPosition(float v)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (direction.normalized * force * v) + 0.5f * Physics2D.gravity * (v * v);
        return currentPointPos;
    }

    private void faceMouse()
    {
        transform.right = direction;
    }
}
