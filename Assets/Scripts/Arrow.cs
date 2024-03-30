using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public Collider2D col2d;

    bool isHit = false;

    private void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isHit == false)
        {
            // Calculate the angle from the direction
            float angle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            isHit = true;
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
