using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverMindEver.Enemy
{
    public abstract class Enemy : MonoBehaviour,IDamageable
    {
        [SerializeField] protected int health;

        [SerializeField] protected int _damage;
        [SerializeField] protected float _speedAtack;

        [Header("Movment")]
        [SerializeField] protected float speed;
        [SerializeField] Transform[] _targetMove;
        protected int _currentTarget=0;
        protected bool _isWalk=true;

        protected Animator _animator;
        protected SpriteRenderer _spriteRender;

        protected bool _isCanTakeDamage = true;


        public virtual void Awake() {
                _animator =GetComponent<Animator>();
                _spriteRender = GetComponent<SpriteRenderer>();
        }

        public virtual void Update() {
            float step = speed * Time.deltaTime;
            if(_isWalk)
                transform.position = Vector2.MoveTowards(transform.position, _targetMove[_currentTarget].position, step);
            if(Vector2.Distance(transform.position, _targetMove[_currentTarget].position)<0.5f)
                StartCoroutine(Wait());
        }

        public void Damage(int damage)
        {
            if(_isCanTakeDamage){
                health -= damage;
                _animator.SetTrigger("Hit");
                StartCoroutine(Invincible());
                _animator.SetBool("InCombat",true);
                _isWalk = false;
                Debug.Log(_isWalk);
                 // StartCoroutine(Freeze());
                if(health<=0)
                    Died();
            }
        }

        public virtual void Died(){
            Destroy(gameObject);
        }

        private IEnumerator Wait(){
            _isWalk = false;
            _animator.SetBool("Walking",_isWalk);
            _currentTarget++;
            if(_currentTarget > _targetMove.Length-1)
                _currentTarget = 0;
            yield return new WaitForSeconds(5);
            _isWalk = true;
            _animator.SetBool("Walking",_isWalk);
            FlipSprite();
        }

        private void FlipSprite(){
            switch(_currentTarget){
                case 0:
                gameObject.transform.rotation = Quaternion.Euler(0,180,0);
                break;
                case 1:
                gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                break;
            }
           
        }

        private IEnumerator Freeze(){
            _isWalk = false;
            yield return new WaitForSeconds(0.5f);
            _isWalk = true;
        }

        private IEnumerator Invincible(){
            _isCanTakeDamage = false;
             yield return new WaitForSeconds(0.5f);
             _isCanTakeDamage = true;
        }

    }
}
