using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            Destroy(collision.gameObject);
            BalloonHandle balloon = new BalloonHandle();
            balloon.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        else if(collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
        }
    }
}
