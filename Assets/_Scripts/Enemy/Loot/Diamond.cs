using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
   [SerializeField] private int _score;

   public void SetScore(int score){
      _score =score;
   }

   private void OnTriggerEnter2D(Collider2D collider){
         if(collider.tag =="Player"){
            collider.GetComponent<Score>().AddScore(_score);
            Destroy(gameObject);
         }
   }
}

