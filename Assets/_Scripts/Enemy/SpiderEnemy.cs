using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverMindEver.Enemy
{
    public class SpiderEnemy : Enemy
    {
        [SerializeField] private GameObject _acid;
        [SerializeField] private float _speedAcid;

        protected override void Update()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            if(Vector3.Distance(transform.position,_playerTransform.position)<5f)
                Combat();
        }

        private void Combat()
        {
            _animator.SetBool("InCombat",true);
            StartCoroutine(Attack());
        }

        protected void SpawnAcid(){
            GameObject acid =Instantiate(_acid,transform.position,Quaternion.identity);

            acid.GetComponent<AcidProjectile>()._damage = _damage; 
        }
        
        private IEnumerator Attack(){
            yield return new WaitForSeconds(_speedAtack);
            _animator.SetTrigger("Attack");
        }

    }
}
