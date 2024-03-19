using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandle : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    public static Action onIsSwitched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            _spriteRenderer.color = Color.green;
            onIsSwitched?.Invoke();
        }
    }
}
