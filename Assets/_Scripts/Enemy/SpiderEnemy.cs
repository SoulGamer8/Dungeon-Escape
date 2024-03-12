using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverMindEver.Enemy
{
    public class SpiderEnemy : Enemy
    {
        [SerializeField] private GameObject _acid;

        protected void SpawnAcid(){
            Instantiate(_acid,transform.position,Quaternion.identity);
        }

    }
}
