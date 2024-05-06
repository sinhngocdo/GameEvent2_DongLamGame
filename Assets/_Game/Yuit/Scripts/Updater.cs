using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private static Updater _instance;

    public static Updater Instance
    {
        get
        {
            // if (_instance) return _instance;
            
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
