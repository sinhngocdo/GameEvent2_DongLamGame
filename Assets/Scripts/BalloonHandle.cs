using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonHandle : MonoBehaviour
{
    public GameObject HangingCat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            HangingCat.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
