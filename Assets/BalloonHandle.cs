using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonHandle : MonoBehaviour
{
    [SerializeField] GameObject HangingCat;

    private void OnDisable()
    {
        HangingCat.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
