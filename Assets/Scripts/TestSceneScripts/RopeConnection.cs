using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestSceneScripts
{
    public class RopeConnection : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _connectedObject;
        [SerializeField] float pullForce = 2f;
        [SerializeField] SpringJoint2D _springJoint;

        [Header("Rope settings")]
        [SerializeField] float _frequency = 0f;

        [SerializeField] float minDistance;

        float distanceBetweenObject;

        private void Start()
        {
            distanceBetweenObject = Vector3.Distance(_connectedObject.transform.position, transform.position);

            _springJoint = GetComponent<SpringJoint2D>();
            _springJoint.connectedBody = _connectedObject;
            _springJoint.distance = distanceBetweenObject;
            _springJoint.frequency = _frequency;
        }

        private void Update()
        {
            PullObjectTogether();
        }

        void PullObjectTogether()
        {
            if (_springJoint.distance <= minDistance)
            {
                _springJoint.distance = minDistance;
            }
            else
            {
                _springJoint.distance -= 1f * Time.deltaTime;
            }

        }
    }
}