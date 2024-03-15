using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _hitBoxSword;

    [SerializeField] public FixedJoystick variableJoystick;

    private bool _jumpReset = true;

    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }


    public void FixedUpdate()
    {
        float move = variableJoystick.Horizontal;
        Flip(move);
        _rigidbody2D.velocity =new Vector2(move * _speed ,_rigidbody2D.velocity.y);
        _playerAnimation.Move(move);
    }

    private void Flip(float move){
           
        if(move< -0.1f)
            gameObject.transform.rotation = Quaternion.Euler(0,180,0);
        else if(move>0.1f)  
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
           
    }

    
    public void Attack(){
        _hitBoxSword.SetActive(true);
        _playerAnimation.Attack();
    }
    public void StopAttack(){
        _hitBoxSword.SetActive(false);
    }

    #region Jump

    public void Jump(){
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x ,_jumpForce);
        StartCoroutine(JumpResetTimer());
        _playerAnimation.Jump(IsGround());
    }

    private bool IsGround(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,1,_layerMask);
        Debug.DrawRay(transform.position, Vector2.down,Color.green);
        if(hit.collider == null)
            return false;
        return true;
    }

    private IEnumerator JumpResetTimer(){
        _jumpReset = false;
        yield return new WaitForSeconds(0.1f);
        _jumpReset = true;
    }
        
    #endregion
   
}
