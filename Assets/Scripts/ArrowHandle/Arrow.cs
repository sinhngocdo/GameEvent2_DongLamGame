using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] [ReadOnlyInspector] protected float z;
    [SerializeField] [ReadOnlyInspector]           bool  lateStart;
    [SerializeField] Collider2D col;

    [SerializeField] protected int         Damage = 5;
    public                     Rigidbody2D rigid;
    public                     Arrow       arrowInteracting;

    protected bool isHit = false;


    protected virtual void Awake()
    {
        isHit = false;
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        col = GetComponent<Collider2D>();
    }

    protected virtual void Start() { }

    protected virtual void Update()
    {
        if (isHit == false)
        {
            // Calculate the angle from the direction
            float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("DotCircle"))
        {
            z -= 5;
        }

        if (collision.CompareTag("Wall") || collision.CompareTag("Ground"))
        {
            isHit = true;

            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //Destroy(gameObject);
        }


        if (collision.gameObject.TryGetComponent<IHittable>(out var hit))
        {
            HitInfo hitInfo = new HitInfo()
            {
                hitPoint = collision.ClosestPoint(new Vector2(this.transform.position.x, this.transform.position.y)),
                Damage   = this.Damage,
            };

            hit.OnHit(hitInfo);
        }
    }
}