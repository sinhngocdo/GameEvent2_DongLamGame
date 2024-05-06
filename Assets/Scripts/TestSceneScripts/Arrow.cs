using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestSceneScripts
{
    public class Arrow : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Cat"))
            {
                ManageRope.instance.SetRopeToTarget(other.gameObject);
                Debug.Log("Touch cat");
            }

            if (other.gameObject.CompareTag("Wall"))
            {
                ManageRope.instance.SetEndRopeToTarget(other.gameObject);
            }
        }
    }

}
