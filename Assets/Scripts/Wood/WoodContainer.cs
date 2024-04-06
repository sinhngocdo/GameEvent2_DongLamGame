using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodContainer : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] _rigidBody2Ds;

    private void Reset()
    {
        _rigidBody2Ds = GetComponentsInChildren<Rigidbody2D>();

        foreach (var item in _rigidBody2Ds)
        {
            item.GetComponent<Rigidbody2D>();
        }
    }

}
