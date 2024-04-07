using UnityEngine;

public interface IHittable
{
    void OnHit(HitInfo hitInfo);
}


public class HitInfo
{
    public Vector2 hitPoint { get; set; }
    public int Damage;
    public float ForceValue;
}