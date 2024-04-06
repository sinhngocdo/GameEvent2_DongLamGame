using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHandle : MonoBehaviour
{
    [SerializeField] GameObject redMark;

    [SerializeField] RopeConnection _ropeConnection;

    bool isActive;

    private void Reset()
    {
        _ropeConnection = GetComponent<RopeConnection>();
        redMark = transform.GetChild(0).gameObject;
    }

    private void Awake()
    {
        isActive = false;
        _ropeConnection.enabled = false;
    }

    private void Update()
    {
        if(GameManager.instance.IsMark)
        {
            _ropeConnection.enabled = true;
        }
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
