using JetBrains.Annotations;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private static Updater instance;

    public static Updater Ins
    {
        get
        {
            if (instance) return instance;

            GameObject singletonObject = new GameObject(typeof(Updater).Name);
            instance = singletonObject.AddComponent<Updater>();
            return instance;

        }
    }

}
