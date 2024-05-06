// using System.Collections;
// using UnityEngine;
//
// public class HittableObject : MonoBehaviour, IHittableObject
// {
//     [SerializeField] private GameObject effectRef;
//     [SerializeField] private AudioClip audio;
//     
//     public virtual void OnHit(HitInfo hit)
//     {
//         GameObject instance = Instantiate(effectRef);
//         instance.transform.position = (new Vector3(hit.hitPoint.x, hit.hitPoint.y, transform.position.z));
//         // AudioManager.Instance.Raise(audio);
//
//         StartCoroutine(HideObject(instance));
//     }
//
//     protected IEnumerator HideObject(GameObject source)
//     {
//         yield return new WaitForSeconds(5);
//         
//         source.SetActive(false);
//     }
// }
//
// public class HitInfo
// {
//     public Vector2 hitPoint { get; set; }
//     public int Damage;
// }