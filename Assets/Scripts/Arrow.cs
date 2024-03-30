using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] [ReadOnlyInspector] protected float z;
    [SerializeField] [ReadOnlyInspector]           bool  lateStart;

    [SerializeField] protected int         Damage = 5;
    public                     Rigidbody2D rigid;
    public                     Arrow       arrowInteracting;


    protected virtual void Awake()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    protected virtual void Start() { }

    protected virtual void Update()
    {
        if (lateStart == false)
        {
            z         = transform.localEulerAngles.z;
            lateStart = true;
        }

        transform.rotation = Quaternion.Euler(0, 0, z);
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DotCircle")
        {
            z -= 5;
        }

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }


        if (collision.gameObject.TryGetComponent<IHittableObject>(out var hit))
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