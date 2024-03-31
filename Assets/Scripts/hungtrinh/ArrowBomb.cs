using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hungtrinh
{
    public class ArrowBomb : Arrow
    {
        [SerializeField] float forceBomb;
        [SerializeField] float bombRange;
        [SerializeField] float scaleArrowCurrent;

        [SerializeField] float maxClampScale;
        [SerializeField] float delayBomb;

        [Header("On Hold Space")] [SerializeField]
        float scaleForce;

        [SerializeField] LayerMask interactBomb;
        private          Vector3   initScale;
        bool                       isAllowScale = true;


        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
            initScale         = transform.localScale;
            scaleArrowCurrent = 1;
        }

        protected override void Update()
        {
            base.Update();
            if (Input.GetKey(KeyCode.Space) && scaleArrowCurrent < maxClampScale && isAllowScale)
            {
                scaleArrowCurrent += scaleForce * Time.deltaTime;
                AppleScaleToArrow(scaleArrowCurrent);
            }
        }

        private void AppleScaleToArrow(float scale)
        {
            var localScale = initScale * scale;
            transform.localScale = localScale;
        }

        private void Bomb()
        {
            Debug.Log("Force Boomb");

            float forceRange = bombRange * scaleArrowCurrent;
            var   result     = Physics2D.OverlapCircleAll(transform.position, forceRange, interactBomb);
            Debug.Log(result.Length);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == null)
                {
                    continue;
                }


                Debug.Log(result[i].name);
                AddExplosionForce(result[i].attachedRigidbody, forceBomb, transform.position, forceRange);
            }
        }


        public static void AddExplosionForce(Rigidbody2D rb, float explosionForce, Vector2 explosionPosition,
            float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
        {
            var explosionDir      = rb.position - explosionPosition;
            var explosionDistance = explosionDir.magnitude;

            // Normalize without computing magnitude again
            if (upwardsModifier == 0)
                explosionDir /= explosionDistance;
            else
            {
                explosionDir.y += upwardsModifier;
                explosionDir.Normalize();
            }

            Debug.Log($"explosionDistance {explosionDistance}");
            Debug.Log($"explosionRadius {explosionRadius}");
            
            rb.AddForce(explosionDir * (Mathf.Lerp(0, explosionForce,1 - (explosionDistance / explosionRadius))), mode);
        }

        private IEnumerator BombDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Bomb();
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("DotCircle"))
            {
                z -= 5;
                return;
            }

            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
            {
                this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                isAllowScale                                        = false;
            }


            if (collision.gameObject.TryGetComponent<IHittableObject>(out var hit))
            {
                HitInfo hitInfo = new HitInfo()
                {
                    hitPoint = collision.ClosestPoint(new Vector2(this.transform.position.x, this.transform.position.y)),
                    Damage   = this.Damage,
                };
                isAllowScale = false;
                hit.OnHit(hitInfo);
            }

            Debug.Log("Bomb");
            StartCoroutine(BombDelay(delayBomb));
        }
    }
}