using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverMindEver.Enemy
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private int _damage;
        private Enemy enemy;


        //private void Start() {
        //    enemy = GetComponent<Enemy>();
        //}

        private void OnTriggerEnter2D(Collider2D other) {
            IDamageable iDamageable = other.GetComponent<IDamageable>();
            if(iDamageable == null) 
                return;
            if(other.tag =="Player")
                iDamageable.TakeDamage(_damage);
        }
    }
}
