using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(float move){
        _animator.SetFloat("Walk",Mathf.Abs(move));
    }

    public void Jump(bool jumping){
        _animator.SetBool("Jumping",!jumping);
    }

    public void Attack(){
        _animator.SetTrigger("Attack");
    }
}
