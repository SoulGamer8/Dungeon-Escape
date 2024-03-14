using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverMindEver.Enemy
{
    public class AcidProjectile : MonoBehaviour
    {

        public int _damage{get;set;}
        
        private void Start() {
            StartCoroutine(TimeExitProjectile());
        }

        private void Update() {
            Movment();
        }

        private void Movment()
        {
           transform.Translate(Vector3.right * 3 * Time.deltaTime);
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

        private IEnumerator TimeExitProjectile(){
            yield return new WaitForSeconds(3);
            Died();
        }
    }
}
