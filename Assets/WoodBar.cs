using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBar : MonoBehaviour
{
    [SerializeField] Transform startPoint; 
    [SerializeField] Transform endPoint;
    [SerializeField] float moveSpeed = 0.1f;

    [SerializeField] bool isMoving = false;
    [SerializeField] bool isStartPoint = false;

    private void OnEnable()
    {
        SwitchHandle.onIsSwitched += MoveWoodBar;
    }

    

    private void OnDisable()
    {
        SwitchHandle.onIsSwitched -= MoveWoodBar;
    }


    private void Start()
    {
        transform.position = startPoint.position;
    }


    private void MoveWoodBar()
    {
        isMoving = true;
        if (isMoving == false)
        {
            Debug.Log("isStartPoint: " + isStartPoint);
            if (isStartPoint == true)
            {
                Debug.Log("isStartPoint: " + isStartPoint);
                StartCoroutine(MoveToTarget(endPoint));
                isStartPoint = false;
            }
            else
            {
                Debug.Log("isStartPoint: " + isStartPoint);
                StartCoroutine(MoveToTarget(startPoint));
                isStartPoint = true;
            }
            
        }
        
    }

    IEnumerator MoveToTarget(Transform targetPosition)
    {
        var startPos = startPoint.position;
        var targetPos = targetPosition.position;

        while (transform.position != targetPos)
        {

            transform.position = Vector3.MoveTowards(startPos, targetPos, moveSpeed);
            yield return null;
        }
    }
}
