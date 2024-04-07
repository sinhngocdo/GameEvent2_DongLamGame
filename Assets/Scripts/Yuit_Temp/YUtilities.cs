using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class YUtilities
{
    public static void ActiveStep (this IList<GameObject> steps, int activeIndex)
    {
        for (var i = 0; i < steps.Count; i++)
        {
            steps[i].SetActive(i == activeIndex);
        }
    }
    
    public static void DelayAction(this MonoBehaviour mono, Action action, float time)
    {
        mono.StartCoroutine(ActiveTime());
        return;

        IEnumerator ActiveTime()
        {
            yield return new WaitForSeconds(time);
            action();
        }
    }

    public static void DelayInactiveObject(this MonoBehaviour mono, GameObject target, float time)
    {
        mono.DelayAction(() => target.SetActive(false), time);
    }
}


public static class Tags
{
    public const string playerTag = "Player";
    public const string hittableTag = "Hittable";
}

public static class LayersID
{
    public const int Default = 0;
    public const int Player = 9;
    public const int Hittable = 11;
}

public static class LayersMask
{
    public const int Default = 1 << LayersID.Default;
    public const int Player = 1 << LayersID.Player;
    public const int Hittable = 1 << LayersID.Hittable;
}

public static class Layers
{
    public const int defaultLayer = 0;
    public const int playerLayer = 9;
    public const int hittableLayer = 11;
}