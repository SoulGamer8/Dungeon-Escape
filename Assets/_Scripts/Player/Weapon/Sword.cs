using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
   [SerializeField] private int _damage;

   private void OnTriggerEnter2D(Collider2D other) {
    IDamageable iDamageable = other.GetComponent<IDamageable>();
    if(iDamageable == null) 
        return;
    if(other.tag =="Enemy")
        iDamageable.Damage(_damage);
   }
}
