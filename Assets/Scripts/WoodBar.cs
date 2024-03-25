using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public enum IsMoving
{
    isMovingToA,
    isMovingToB,
    isStayA,
    isStayB
}

public class WoodBar : MonoBehaviour
{
    [SerializeField] Transform positionA;
    [SerializeField] Transform positionB;
    [SerializeField] float moveSpeed = 10f;

    IsMoving isMoving;

    private void OnEnable()
    {
        SwitchHandle.onIsSwitched += MoveWoodBarIsTrue;
    }

    

    private void OnDisable()
    {
        SwitchHandle.onIsSwitched -= MoveWoodBarIsTrue;
    }


    private void Start()
    {
        transform.position = positionA.position;
        isMoving = IsMoving.isStayA;
    }

    private void Update()
    {
        MoveWoodBar();
        
    }



    #region MoveWoodBar
    void MoveWoodBar()
    {
        if (isMoving == IsMoving.isMovingToA)
        {
            Debug.Log("isMoveToA");
            transform.position = Vector3.MoveTowards(transform.position, positionA.position, moveSpeed * Time.deltaTime);
            if(transform.position == positionA.position)
            {
                isMoving = IsMoving.isStayA;
            }
        }
        if (isMoving == IsMoving.isMovingToB)
        {
            Debug.Log("isMoveToB");
            transform.position = Vector3.MoveTowards(transform.position, positionB.position, moveSpeed * Time.deltaTime);
            if(transform.position == positionB.position)
            {
                isMoving = IsMoving.isStayB;
            }
        }
    }

    void MoveWoodBarIsTrue()
    {
        if(isMoving == IsMoving.isStayA)
        {
            isMoving = IsMoving.isMovingToB;
        }
        if(isMoving == IsMoving.isStayB)
        {
            isMoving = IsMoving.isMovingToA;
        }
    }

    #endregion
}
