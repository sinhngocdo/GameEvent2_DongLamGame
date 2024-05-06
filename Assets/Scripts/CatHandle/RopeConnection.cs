using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;


public class RopeConnection : MonoBehaviour, ILinkerWire
{
    [SerializeField] Rigidbody2D _connectedObject;

    [SerializeField] float pullForce = 2f;

    // [SerializeField] SpringJoint2D _springJoint;
    [SerializeField, ReadOnly] SpringJoint2D wire;
    [SerializeField] CatHandle _catHandle;

    [SerializeField] LineRenderer _lineRenderer;


    [Header("Rope settings")] [SerializeField]
    float _frequency = 0f;

    [SerializeField] float minDistance;

    float distanceBetweenObject;

    private void Reset()
    {
        // _springJoint = GetComponent<SpringJoint2D>();
        _catHandle = GetComponent<CatHandle>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        // _springJoint.enabled = true;
        _lineRenderer.enabled = true;
    }

    private void OnDisable()
    {
        // _springJoint.enabled = false;
        _lineRenderer.enabled = false;
    }


    private void Start()
    {
        distanceBetweenObject = Vector3.Distance(_connectedObject.transform.position, transform.position);


        // _springJoint.connectedBody = _connectedObject;
        // _springJoint.distance = distanceBetweenObject;
        // _springJoint.frequency = _frequency;
    }

    private void Update()
    {
        PullObjectTogether();
        DrawLine();
    }

    void PullObjectTogether()
    {
        // if (_springJoint.distance <= minDistance)
        // {
        //     _springJoint.distance = minDistance;
        //     _connectedObject.bodyType = RigidbodyType2D.Static;
        // }
        // else
        // {
        //     _springJoint.distance -= 1f * Time.deltaTime;
        // }
    }

    void DrawLine()
    {
        _lineRenderer.SetPosition(0, this.transform.position);
        _lineRenderer.SetPosition(1, _connectedObject.transform.position);
    }

    public Rigidbody2D GetTarget()
    {
        return _connectedObject;
    }

    public SpringJoint2D CreateWire()
    {
        if (!this.TryGetComponent<SpringJoint2D>(out wire))
        {
            wire = gameObject.AddComponent<SpringJoint2D>();
        }
        return wire;
    }

    public void RemoveWire()
    {
        wire.enabled = false;
    }
}