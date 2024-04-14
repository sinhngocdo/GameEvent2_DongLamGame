using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WireShooterTest : MonoBehaviour
{
    // public RopeConnection target1;
    // public RopeConnection target2;
    public Rigidbody2D target1;
    public Rigidbody2D target2;

    [SerializeField] private WireConnector wire;

    [SerializeField, Range(0, 3f)]
    private float timerConnector;

    [SerializeField, Range(0, 1f)]
    private float distancePercent;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && target1 && target2)
        {
            Debug.Log("Shooted");
            // YUtilities.LinkWithSpringJoint(target1, target2, distancePercent, timerConnector);
            wire.LinkWithSpringJoint(target1, target2, distancePercent, timerConnector);
        }
    }
}
