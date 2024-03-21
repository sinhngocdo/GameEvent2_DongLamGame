using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandle : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    private bool isEnabled = false;

    public static Action onIsSwitched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            if (isEnabled == false)
            {
                _spriteRenderer.color = Color.green;
                isEnabled = true;
            }
            else
            {
                _spriteRenderer.color = Color.red;
                isEnabled = false;
            }
            
            onIsSwitched?.Invoke();
        }
    }
}
