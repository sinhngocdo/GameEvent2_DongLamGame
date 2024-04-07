using System.Collections;
using UnityEngine;

public class HittableObject : MonoBehaviour, IHittable
{
     [SerializeField] private GameObject effectRef;
     [SerializeField] private AudioClip audio;
    
    
     private ObstacleNetwork _obstacleNetwork;
    public ObstacleNetwork ObstacleNetwork
    {
        get
        {
            if (_obstacleNetwork) return _obstacleNetwork;

            _obstacleNetwork = GetComponentInParent<ObstacleNetwork>();
            return _obstacleNetwork;
        }
    }

    public void OnHit(HitInfo hitInfo)
    {
         GameObject instance = Instantiate(effectRef);
         instance.transform.position = hitInfo.hitPoint;
         ObstacleNetwork.TakeDamage(hitInfo.Damage);
         // AudioManager.Instance.Raise(audio);

         StartCoroutine(HideObject(instance));
     }

     protected IEnumerator HideObject(GameObject source)
     {
         yield return new WaitForSeconds(5);
         
         source.SetActive(false);
    }
}
