using System;
using System.Collections.Generic;
using hungtrinh;
using Ngocsinh.Observer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public enum ArrowType
{
    normal   = 5,
    threeray = 10,
    bomb     = 15,
    control  = 20,
    Wire     = 25,
    RedHeart = 30,
    BlueHeart = 35,
}

public class BulletShooting : MonoBehaviour
{
    [Header("****Bullet display****")] 
    [SerializeField]
    Transform shootPoint;

    private CustomInput playerInput;
    [SerializeField] private InputAction mouseClick;
    
    [Header("WIRE")]
    [SerializeField] private Arrow arrowWire;
    public ILinkerWire linkerForm;

    [Header("INPUT")]
    // [SerializeField] Arrow     arrowNormal;
    // [SerializeField] Arrow     arrow3ray;
    // [SerializeField] Arrow     arrowBomb;
    // [SerializeField] Arrow     arrowControl;
    [SerializeField] private Arrow arrowRedHeart;
    [SerializeField] private Arrow arrowBlueHeart;
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

    [FormerlySerializedAs("isShootable")]
    [Header("***Other***")] 
    [SerializeField]
    private bool isBlueShootable = true;
    [SerializeField]
    private bool isRedShootable = true;

    private void Start()
    {
        fireElapsedTime = fireRate;
        isBlueShootable = true;
        isRedShootable = false;
        nextTypeArrowFire = ArrowType.BlueHeart;

        playerInput = new CustomInput();
        mouseClick = playerInput.Player.MouseClick;
        playerInput.Player.Enable();
        
        this.RegisterListener(EventID.OnBlueShootable, (param) => OnBlueShootable());
        this.RegisterListener(EventID.OnRedShootable, (param) => OnRedShootable());
        this.RegisterListener(EventID.OnBlueStopShoot, (param) => OnBlueStopShoot());
        this.RegisterListener(EventID.OnRedStopShoot, (param) => OnRedStopShoot());
    }

    private void Update()
    {
        if (isBlueShootable)
        {
            Shoot(nextTypeArrowFire);
        }
        else if (isRedShootable)
        {
            Shoot(nextTypeArrowFire);
        }
        ChangeArrowToShoot();

    }

    void OnBlueShootable()
    {
        isBlueShootable = true;
    }

    void OnRedShootable()
    {
        isRedShootable = true;
    }

    void OnBlueStopShoot()
    {
        isBlueShootable = false;
    }

    void OnRedStopShoot()
    {
        isRedShootable = false;
    }

    private void Shoot(ArrowType arrowType)
    {
        fireElapsedTime += Time.deltaTime;
        if (mouseClick.IsPressed() && fireElapsedTime >= fireRate)
        {
            // if (nextTypeArrowFire == ArrowType.BlueHeart)
            // {
            //     BulletShootHandle();
            // }

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
        if (mouseClick.WasReleasedThisFrame() && fireElapsedTime >= fireRate /*&& arrowIntaracting == null*/)
        {
            BulletShootHandle(arrowType);
        }
    }

    private void ChangeArrowToShoot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Change Arrow to blue head");
            isBlueShootable = true;
            isRedShootable = false;
            nextTypeArrowFire = ArrowType.BlueHeart;
        }

        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     nextTypeArrowFire = ArrowType.threeray;
        // }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Change Arrow to red head");
            isBlueShootable = false;
            isRedShootable = true;
            nextTypeArrowFire = ArrowType.RedHeart;
        }
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     nextTypeArrowFire = ArrowType.control;
        // }
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     nextTypeArrowFire = ArrowType.Wire;
        // }
    }


    void BulletShootHandle(ArrowType arrowType)
    {
        Arrow arrowFire = null;
        switch (arrowType)
        {
            // case ArrowType.normal:
            //     arrowFire = Instantiate(arrowNormal, shootPoint.position, shootPoint.rotation);
            //     break;
            // case ArrowType.threeray:
            //     arrowFire = Instantiate(arrow3ray, shootPoint.position, shootPoint.rotation);
            //     break;
            // case ArrowType.bomb:
            //     arrowFire = Instantiate(arrowBomb, shootPoint.position, shootPoint.rotation);
            //     break;
            // case ArrowType.control:
            //     arrowFire = Instantiate(arrowControl, shootPoint.position, shootPoint.rotation);
            //     break;
            case ArrowType.RedHeart:
                arrowFire = Instantiate(arrowRedHeart, shootPoint.position, shootPoint.rotation);
                break;
            case ArrowType.BlueHeart:
                arrowFire = Instantiate(arrowBlueHeart, shootPoint.position, shootPoint.rotation);
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