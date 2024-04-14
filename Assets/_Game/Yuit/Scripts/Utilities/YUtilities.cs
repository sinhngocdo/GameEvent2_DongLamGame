using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class YUtilities
{
    public static bool LinkWithSpringJoint(ILinkerWire targetFrom, ILinkerWire targetTo, float percentDistance, float linkTime)
    {
        var rigidbodyTo = targetTo.GetTarget();
        if (!rigidbodyTo) return false;

        var springData = targetFrom.CreateWire();
        springData.connectedBody = rigidbodyTo;

        springData.autoConfigureDistance = false;
        springData.distance = Vector2.Distance(rigidbodyTo.transform.position, springData.transform.position) * percentDistance;
        springData.enabled = true;
        
        Updater.Instance.Delay(linkTime, targetFrom.RemoveWire);
        return true;
    }

    public static bool LinkWithSpringJoint(this WireConnector wire, Rigidbody2D from, Rigidbody2D to, float percentDistance, float linkTime)
    {
        if (!from || !to) return false;

        wire.Init(from, to);
        wire.transform.SetPositionAndRotation(GetPointBetweenTransforms(from.transform, to.transform) + Vector3.up * 5, Quaternion.identity);
        wire.Raise(percentDistance, linkTime);

        return true;
    }

    public static Vector3 GetPointBetweenTransforms(Transform transform1, Transform transform2)
    {
        return (transform1.position + transform2.position) / 2f;;
    }

    
    public static void ActiveStep(this IList<GameObject> steps, int activeIndex)
    {
        for (var i = 0; i < steps.Count; i++)
        {
            steps[i].SetActive(i == activeIndex);
        }
    }
    
    public static void Delay(this MonoBehaviour mono, float time, Action action)
    {
        if (!CheckerCoroutine(mono, action)) return;
        mono.StartCoroutine(ActiveTime());
        return;

        IEnumerator ActiveTime()
        {
            yield return new WaitForSeconds(time);
            action();
        }
    }

    public static void Delay(this MonoBehaviour mono, int frame, Action action)
    {
        if (!CheckerCoroutine(mono, action)) return;
        mono.StartCoroutine(ActiveTime());
        return;
        
        IEnumerator ActiveTime()
        {
            for (var i = 0; i < frame; i++)
            {
                yield return null;
            }
            action();
        }
    }

    public static void DelayInactiveObject(this MonoBehaviour mono, float time, GameObject target)
    {
        mono.Delay(time, () =>
        {
            if (target) target.SetActive(false);
        });
    }

    private static bool CheckerCoroutine(MonoBehaviour mono, Action action)
    {
        return mono && mono.isActiveAndEnabled && action != null;
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