using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHandle : MonoBehaviour
{
    [SerializeField] GameObject redMark;

    bool isActive;

    private void Awake()
    {
        isActive = false;
    }

    public bool IsShoot()
    {
        return isActive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            ChangeActive();
        }
    }

    void ChangeActive()
    {
        isActive = !isActive;
        redMark.SetActive(isActive);
    }
}
