using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverMindEver.Enemy
{
    public class AcidProjectile : MonoBehaviour
    {

        private int _damage;

        private void Update() {
            Movment();
        }

        private void Movment()
        {
            transform.position += Vector3.left;            
        }

        private void OnTriggerEnter2D(Collider2D other) {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if(damageable == null)
                return;
            if(other.tag == "Player"){
                damageable.TakeDamage(_damage);
                Died();    
            }
       }

       private void Died(){
        Destroy(gameObject);
       }
    }
}
