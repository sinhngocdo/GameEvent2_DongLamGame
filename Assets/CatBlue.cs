using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBlue : CatAI
{

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            base.isJumpEnabled = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            base.isJumpEnabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            base.isJumpEnabled = false;
        }
    }
}
