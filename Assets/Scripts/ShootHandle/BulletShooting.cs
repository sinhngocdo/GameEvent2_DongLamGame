using System;
using System.Collections.Generic;
using hungtrinh;
using UnityEngine;


public enum ArrowType
{
    normal   = 5,
    threeray = 10,
    bomb     = 15,
    control  = 20,
    Wire     = 25,
}

public class BulletShooting : MonoBehaviour
{
    [Header("****Bullet display****")] [SerializeField]
    Transform shootPoint;
    
    [Header("WIRE")]
    [SerializeField] private Arrow arrowWire;
    public ILinkerWire linkerForm;

    [Header("INPUT")]
    [SerializeField] Arrow     arrowNormal;
    [SerializeField] Arrow     arrow3ray;
    [SerializeField] Arrow     arrowBomb;
    [SerializeField] Arrow     arrowControl;
    [SerializeField] float     bulletSpeed       = 0f;
    [SerializeField] float     speedGathering    = 2f;
    [SerializeField] ArrowType nextTypeArrowFire = ArrowType.normal;


    [Space] [Header("DelayShoot")] [SerializeField]
    float fireRate = 0.2f;

    [SerializeField] [ReadOnlyInspector] float fireElapsedTime = 0;
    [SerializeField]                     Arrow arrowIntaracting;

    private float bulletSpeedMax = 30f;

    [Header("****trajectory display****")] [SerializeField]
    LineRenderer lineRenderer;

    [SerializeField] int   linePoints           = 15;
    [SerializeField] float timeIntervalinPoints = 0.1f;

    private void Start()
    {
        fireElapsedTime = fireRate;
        nextTypeArrowFire = ArrowType.Wire;
    }

    private void Update()
    {
        fireElapsedTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && fireElapsedTime >= fireRate)
        {
            if (nextTypeArrowFire == ArrowType.control)
            {
                BulletShootHandle();
            }

            if (bulletSpeed < bulletSpeedMax)
            {
                bulletSpeed += speedGathering * Time.deltaTime;
            }

            if (lineRenderer != null)
            {
                DrawTrajectory();
                lineRenderer.enabled = true;
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }


        //press space up to shoot
        if (Input.GetMouseButtonUp(0) && fireElapsedTime >= fireRate /*&& arrowIntaracting == null*/)
        {
            BulletShootHandle();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            nextTypeArrowFire = ArrowType.normal;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            nextTypeArrowFire = ArrowType.threeray;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            nextTypeArrowFire = ArrowType.bomb;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            nextTypeArrowFire = ArrowType.control;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            nextTypeArrowFire = ArrowType.Wire;
        }

    }


    void BulletShootHandle()
    {
        Arrow arrowFire = null;
        switch (nextTypeArrowFire)
        {
            case ArrowType.normal:
                arrowFire = Instantiate(arrowNormal, shootPoint.position, shootPoint.rotation);
                break;
            case ArrowType.threeray:
                arrowFire = Instantiate(arrow3ray, shootPoint.position, shootPoint.rotation);
                break;
            case ArrowType.bomb:
                arrowFire = Instantiate(arrowBomb, shootPoint.position, shootPoint.rotation);
                break;
            case ArrowType.control:
                arrowFire = Instantiate(arrowControl, shootPoint.position, shootPoint.rotation);
                break;
            case ArrowType.Wire:
                arrowFire = Instantiate(arrowWire, shootPoint.position, shootPoint.rotation);
                (arrowFire as ArrowWire)!.shooterSource = this;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        arrowIntaracting           = arrowFire;
        arrowFire.arrowInteracting = arrowFire;
        if (arrowFire != null)
        {
            arrowFire.GetComponent<Rigidbody2D>().velocity = bulletSpeed * shootPoint.right;
            ResetValue();
        }
    }

    void DrawTrajectory()
    {
        Vector2 origin        = shootPoint.position;
        Vector2 startVelocity = bulletSpeed * shootPoint.right;
        lineRenderer.positionCount = linePoints;

        float time = 0;

        for (int i = 0; i < linePoints; i++)
        {
            //s = u*t + 1/2*g*t*t
            var     x     = (startVelocity.x * time) + (Physics2D.gravity.x / 2 * time * time);
            var     y     = (startVelocity.y * time) + (Physics2D.gravity.y / 2 * time * time);
            Vector2 point = new Vector2(x, y);
            lineRenderer.SetPosition(i, origin + point);
            time += timeIntervalinPoints;
        }
    }

    void ResetValue()
    {
        bulletSpeed          = 2f;
        lineRenderer.enabled = false;
        fireElapsedTime      = 0;
    }
}