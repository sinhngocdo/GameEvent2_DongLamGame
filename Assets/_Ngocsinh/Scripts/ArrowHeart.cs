using System;
using System.Collections;
using System.Collections.Generic;
using Ngocsinh.Observer;
using UnityEngine;

public enum ArrowHearType
{
    Red,
    Blue
}

public class ArrowHeart : Arrow
{
    public ArrowHearType arrowHeartType;


    private void OnEnable()
    {
        if (arrowHeartType == ArrowHearType.Blue)
        {
            this.PostEvent(EventID.OnBlueStopShoot);
        }
        else if (arrowHeartType == ArrowHearType.Red)
        {
            this.PostEvent(EventID.OnRedStopShoot);
        }
        
    }

    private void OnDisable()
    {
        this.PostEvent(EventID.OnArrowHeartDestroy);
        if (arrowHeartType == ArrowHearType.Blue)
        {
            this.PostEvent(EventID.OnBlueShootable);
        }
        else if (arrowHeartType == ArrowHearType.Red)
        {
            this.PostEvent(EventID.OnRedShootable);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        this.PostEvent(EventID.OnWalkable);
        if (collision.gameObject.CompareTag("Cat"))
        {
            CatAI catAI = collision.gameObject.GetComponent<CatAI>();

            if (catAI != null && catAI.arrowType == this.arrowHeartType)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
