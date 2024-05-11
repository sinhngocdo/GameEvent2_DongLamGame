using System;
using System.Collections;
using System.Collections.Generic;
using Ngocsinh.Observer;
using UnityEngine;

public class Gai : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            Debug.Log("Lose game");
            this.PostEvent(EventID.OnLoseGame);
        }
    }
}