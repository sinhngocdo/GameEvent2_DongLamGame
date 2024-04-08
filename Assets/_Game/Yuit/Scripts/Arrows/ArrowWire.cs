using UnityEngine;

public class ArrowWire : Arrow
{
    public BulletShooting shooterSource;
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ILinkerWire>(out var target))
        {
            if (shooterSource.linkerForm == null)
            {
                shooterSource.linkerForm = target;
            }

            else if (shooterSource.linkerForm != target)
            {
                YUtilities.LinkWithSpringJoint(shooterSource.linkerForm, target, .3f, 1f);
                shooterSource.linkerForm = null;
            }
        }
    }
}
