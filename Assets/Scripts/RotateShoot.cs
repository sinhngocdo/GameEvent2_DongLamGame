using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShoot : MonoBehaviour
{
    [SerializeField] float rotateSpeed;


    private void Start()
    {

    }

    private void LateUpdate()
    {
        //use A or D to rotate hand t shoot
        if (Input.GetKey(KeyCode.A))
        {
            float currentZRotation = transform.rotation.eulerAngles.z;

            float newZRotation = currentZRotation + rotateSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, 0, newZRotation);
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            float currentZRotation = transform.rotation.eulerAngles.z;

            float newZRotation = currentZRotation - rotateSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, 0, newZRotation);
        }

        
    }
}
