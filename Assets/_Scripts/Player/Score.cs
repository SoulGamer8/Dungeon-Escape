using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;


    public int GetScore(){
        return _score;
    }    
    public void AddScore(int score){
        _score +=score;
    }
}
