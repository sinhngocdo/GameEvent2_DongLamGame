using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestSceneScripts
{
    public class Rope : MonoBehaviour
    {
        public Rigidbody2D hook;
        public GameObject linkPrefab;
        public Weight weigth;
        public int links = 7;
        public HingeJoint2D hingeJoint2D;

        public GameObject marked;
	
	
        GameObject link;

        private void OnEnable()
        {
            GenerateRope();
        }

        private void OnDisable()
        {
            
        }

        void Start () {
            // GenerateRope();
            hingeJoint2D.GetComponent<HingeJoint2D>();
            // hook.transform.position = transform.position;
            transform.position = marked.transform.position;
            hingeJoint2D.connectedAnchor = transform.position;

            
        }

        private void Update()
        {
            transform.position = marked.transform.position;
            hingeJoint2D.connectedAnchor = transform.position;
        }

        void GenerateRope ()
        {
            Rigidbody2D previousRB = hook;
		
            for (int i = 0; i < links; i++) //create ropes
            {
                link = Instantiate(linkPrefab, transform);
                HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
                joint.connectedBody = previousRB;
                previousRB = link.GetComponent<Rigidbody2D>();
			
            }
            weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
        }
    }

}
