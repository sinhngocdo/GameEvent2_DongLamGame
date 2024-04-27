using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Pathfinding;

public class CatAI : MonoBehaviour
{
    [Header("Pathfinding")] 
    [CanBeNull] private GameObject target;
    public float activateDistance = 50f;
    public float pathUpdateSecond = 0.5f;

    [Header("Physics")] 
    public float speed = 2f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("CustomBehaviour")] 
    public bool isFollowEnabled = true;
    public bool isJumpEnabled = true;
    public bool isDirectionLookEnabled = true;


    private Path _path;
    private int currentWaypoint = 0;
    private bool isGrounded = false;
    private Seeker _seeker;
    private Rigidbody2D _rb;

    [SerializeField] private ArrowHearType arrowType;

    private void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();

        target = null;
        
        InvokeRepeating("UpdatePath", 0f, pathUpdateSecond);
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            UpdateTarget();
        }
        
        if (TargetInDistance()  && isFollowEnabled)
        {
            PathFollow();
        }

        
    }


    void UpdateTarget()
    {
        if (arrowType == ArrowHearType.Blue)
        {
            target = GameObject.FindWithTag("Blue");
            if (target != null)
            {
                Debug.Log(target.name);
            }
        }
        if (arrowType == ArrowHearType.Red)
        {
            target = GameObject.FindWithTag("Red");
            if (target != null)
            {
                Debug.Log(target.name);
            }
        }
    }

    void UpdatePath()
    {
        if (target != null)
        {
            if (isFollowEnabled && TargetInDistance() && _seeker.IsDone())
            {
                _seeker.StartPath(_rb.position, target.transform.position, OnPathComplelete);
            }
        }
        
        
    }

    void PathFollow()
    {
        if (_path == null)
        {
            return;
        }

        if (currentWaypoint >= _path.vectorPath.Count)
        {
            return;
        }

        isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);

        Vector2 direction = ((Vector2)_path.vectorPath[currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        //jump
        if (isJumpEnabled && isGrounded)
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                _rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }
        
        //movement
        _rb.AddForce(force);
        
        //next waypoint
        float distance = Vector2.Distance(_rb.position, _path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        
        //direction graphic handle
        if (isDirectionLookEnabled)
        {
            if (_rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            }
            else if (_rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            }
            
        }
        
        

    }
    
    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    void OnPathComplelete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            currentWaypoint = 0;
        }
    }
    
}
