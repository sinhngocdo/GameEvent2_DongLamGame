using System;
using System.Collections;
using System.Collections.Generic;
using Ngocsinh.Observer;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            Debug.Log(collision.gameObject.name);
            this.PostEvent(EventID.OnWinGame);
        }
    }
}
