using NaughtyAttributes;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    [ReadOnly]
    public ExplosionData explosionData;

    private RaycastHit2D[] listRay = new RaycastHit2D[50];

    public ExplosionForce(ExplosionData explosionData)
    {
        this.explosionData = explosionData;
    }

    public void SetupExplosion(ExplosionData explosionData)
    {
        this.explosionData = explosionData;
        transform.position = this.explosionData.CenterExpolosion;
        listRay = new RaycastHit2D[50];
    }

    public void SpawnExplosion()
    {
        var size = Physics2D.CircleCastNonAlloc(explosionData.CenterExpolosion, explosionData.Radius, Vector2.zero, listRay, 0, LayersMask.Hittable);

        for (var i = 0; i < size; i++)
        {
            var hitInfo = new HitInfo()
            {
                Damage = explosionData.Damage,
                ForceValue = explosionData.ForceValue,
                hitPoint = listRay[i].point
            };
            listRay[i].collider.GetComponent<IHittable>()?.OnHit(hitInfo);
        }
        
        this.DelayInactiveObject(this.gameObject, 5);
    }
}
