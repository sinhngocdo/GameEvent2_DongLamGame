using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestSceneScripts
{
    public class Weight : MonoBehaviour
    {
        public float distanceFromChainEnd = 0.6f;
        public GameObject endMark;


        private void Start()
        {
            transform.position = endMark.transform.position;
        }

        private void Update()
        {
            transform.position = endMark.transform.position;
        }

        public void ConnectRopeEnd (Rigidbody2D endRB)
        {
            HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedBody = endRB;
            joint.anchor = Vector2.zero;
            joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);
        }
    }

}
