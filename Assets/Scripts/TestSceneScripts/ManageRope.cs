using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestSceneScripts
{
    public class ManageRope : MonoBehaviour
    {
        public static ManageRope instance;

        public GameObject player;
        public GameObject rope;
        public GameObject endRope;

        public int state;
        
        
        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            rope.transform.localPosition = player.transform.localPosition;

            state = 0;
            
            // rope.SetActive(false);
        }

        private void Update()
        {
            if (state == 2)
            {
                rope.SetActive(true);
            }
        }

        public void SetRopeToTarget(GameObject target)
        {
            rope.transform.position = target.transform.position;
            if (state < 2)
            {
                state += 1;
            }
        }

        public void SetEndRopeToTarget(GameObject target)
        {
            endRope.transform.position = target.transform.position;
            if (state == 0)
            {
                state = 2;
            }
        }

        void ResetValue()
        {
            state = 1;
            rope.SetActive(false);
        }
        
    }

}
