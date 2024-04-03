using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class RotateShoot : MonoBehaviour
{
    [Header("Rotate Speed")]
    [SerializeField] float initRotateSpeed;
    [SerializeField][ReadOnlyInspector] float currentRotateSpeed;
    [SerializeField] float maxRotateSpeed;

    bool isRotating = false;

    [Header("Hold Time")]
    [SerializeField] [ReadOnlyInspector] float holdTime;
    [SerializeField] float maxHoldTime;

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
            currentRotateSpeed = initRotateSpeed;
        }

        
        if(isRotating )
        {
            holdTime = (Time.time - pressStartTime) > maxHoldTime ? maxHoldTime : (Time.time - pressStartTime);
            currentRotateSpeed = (currentRotateSpeed > maxRotateSpeed) ? maxRotateSpeed : (currentRotateSpeed + holdTime);

            rotateAmount = Input.GetKey(KeyCode.A) ? 1f : -1f;
            transform.Rotate(Vector3.forward, rotateAmount * currentRotateSpeed * Time.deltaTime);
            
        }

        
    }

}
