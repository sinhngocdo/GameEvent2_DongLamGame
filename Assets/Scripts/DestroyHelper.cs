using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHelper : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
