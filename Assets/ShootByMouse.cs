using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class ShootByMouse : MonoBehaviour
{
    Camera cam;

    
    [SerializeField] GameObject arrowPrefab;
    public Trajectory trajectory;
    [SerializeField] Transform shootPoint;
    [SerializeField] Transform startPosTrajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 0.1f;
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;
            isDragging = false;
            OnDragEnd();
        }
        if (isDragging)
        {
            OnDrag();
        }
    }

    #region Drag
    private void OnDragStart()
    {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    private void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = distance * direction * pushForce;

        trajectory.UpdateDots(startPosTrajectory.transform.position, force);
    }

    private void OnDragEnd()
    {
        Shoot();

        trajectory.Hide();
    }

    private void Shoot()
    {
        GameObject newArrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * force;
    }

    #endregion


}
