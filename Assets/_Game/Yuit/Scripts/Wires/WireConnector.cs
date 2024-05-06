using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnector : MonoBehaviour
{
    public SpringJoint2D targetForm;
    public SpringJoint2D targetTo;
    
    public void Init(Rigidbody2D bodyFrom, Rigidbody2D bodyTo)
    {
        targetForm.connectedBody = bodyFrom;
        targetTo.connectedBody = bodyTo;
    }

    public void Raise(float percentDistance, float connectTime)
    {
        targetForm.distance = percentDistance * Vector2.Distance(this.transform.position, targetForm.transform.position);
        targetTo.distance = percentDistance * Vector2.Distance(this.transform.position, targetTo.transform.position);

        targetForm.enabled = true;
        targetTo.enabled = true;
        
        Updater.Instance.Delay(connectTime, () =>
        {
            if (!this) return;
            targetForm.enabled = false;
            targetTo.enabled = false;
        });
    }
}