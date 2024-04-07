using UnityEngine;

[System.Serializable]
public class ExplosionData
{
    public Vector3 CenterExpolosion;
    public int Damage;
    public int Radius;
    public float ForceValue;

    public ExplosionData(Vector3 centerExpolosion)
    {
        CenterExpolosion = centerExpolosion;
        Damage = 0;
        Radius = 0;
        ForceValue = 0;
    }
}
