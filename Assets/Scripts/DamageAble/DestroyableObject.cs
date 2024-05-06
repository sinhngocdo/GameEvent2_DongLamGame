// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class DestroyableObject : HittableObject
// {
//     [SerializeField] private float healh;
//     [SerializeField] private GameObject destroyObject;
//     
//     public override void OnHit(HitInfo hit)
//     {
//         healh -= hit.Damage;
//         if (healh <= 0) DestroyObj();
//         
//         else base.OnHit(hit);
//     }
//
//     private void DestroyObj()
//     {
//         var obj = Instantiate(destroyObject);
//         obj.transform.position = this.transform.position;
//         
//         this.gameObject.SetActive(false);
//         Updater.Ins.StartCoroutine(HideObject(obj));
//     }
// }
