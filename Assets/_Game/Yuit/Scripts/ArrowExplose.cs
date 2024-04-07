using System;
using UnityEngine;

public class ArrowExplose : Arrow
{
    [SerializeField]
    protected GameObject explosionPrefab;
    
    [SerializeField]
    protected ExplosionData explosionData;


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DotCircle"))
        {
            z -= 5;
        }
        
        else if (collision.gameObject.CompareTag("Ground") || (collision.gameObject.CompareTag("Wall")))
        {
            isHit = true;
            var explosionSpawned = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if (explosionSpawned && explosionSpawned.TryGetComponent<ExplosionForce>(out var explosionForce))
            {
                explosionData.CenterExpolosion = collision.ClosestPoint(transform.position);
                explosionForce.SetupExplosion(explosionData);
                explosionForce.SpawnExplosion();
            }
            this.gameObject.SetActive(false);
        }
    }
}
