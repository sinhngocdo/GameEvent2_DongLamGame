using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShoot : MonoBehaviour
{
    [SerializeField] float initRotateSpeed;
    [SerializeField] float currentRotateSpeed;

    bool isRotating = false;

    float stepTime;
    float rotateAmount;
    float pressStartTime; // thoi diem bat dau nhan nut

    private void Start()
    {

    }

    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            isRotating = true;
            pressStartTime = Time.time;
            currentRotateSpeed = initRotateSpeed;
        }

        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isRotating = false;
        }

        
        if(isRotating )
        {
            stepTime = Time.time - pressStartTime;
            currentRotateSpeed += stepTime;

            rotateAmount = Input.GetKey(KeyCode.A) ? 1f : -1f;
            transform.Rotate(Vector3.forward, rotateAmount * currentRotateSpeed * Time.deltaTime);
            
        }

        
    }
}
