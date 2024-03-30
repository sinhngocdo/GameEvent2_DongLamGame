using System;
using hungtrinh;
using UnityEngine;


public enum ArrowType
{
    normal   = 5,
    threeray = 10,
    bomb     = 15,
    control  = 20
}

public class BulletShooting : MonoBehaviour
{
    [Header("****Bullet display****")] [SerializeField]
    Transform shootPoint;

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
    }

    private void Update()
    {
        fireElapsedTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && fireElapsedTime >= fireRate)
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
        if (Input.GetKeyUp(KeyCode.Space) && fireElapsedTime >= fireRate /*&& arrowIntaracting == null*/)
        {
            BulletShootHandle();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nextTypeArrowFire = ArrowType.normal;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nextTypeArrowFire = ArrowType.threeray;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nextTypeArrowFire = ArrowType.bomb;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            nextTypeArrowFire = ArrowType.control;
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