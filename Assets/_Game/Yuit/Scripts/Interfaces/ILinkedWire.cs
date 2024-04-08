using UnityEngine;

public interface ILinkerWire
{
    Rigidbody2D GetTarget();
    SpringJoint2D CreateWire();
    void RemoveWire();
}