using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverMindEver.Enemy
{
    public abstract class Enemy : MonoBehaviour,IDamageable
    {
        [Header("Health")]
        [SerializeField] protected int health;



        [Header("Movment")]
        [SerializeField] protected float speed;
        [SerializeField] Transform[] _targetMove;
        protected int _currentTarget=0;
        protected bool _isWalk=true;

        [Header("Attack")]
        [SerializeField] protected int _damage;
        [SerializeField] protected float _speedAtack;
        protected bool _isCanTakeDamage = true;
        protected bool _isInCombaStatus=false;


        protected Animator _animator;
        protected SpriteRenderer _spriteRender;

        private Transform _playerTransform;

        public virtual void Awake() {
                _animator =GetComponent<Animator>();
                _spriteRender = GetComponent<SpriteRenderer>();
        } 

        private void Start() {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public virtual void Update() {
            Debug.Log(_isWalk==true);
            if(_isWalk==true && _isInCombaStatus == false)
                Movment();
            if(_isInCombaStatus == true)
                if(Vector2.Distance(transform.position, _targetMove[_currentTarget].position)>2f){
                    _isInCombaStatus=false;
                    _animator.SetBool("InCombat",_isInCombaStatus);
                    _isWalk=true;
                }
        }

        

        #region Damage 
        
        public void Damage(int damage)
        {
            if(_isCanTakeDamage){
                health -= damage;
                
                _animator.SetTrigger("Hit");
                _animator.SetBool("InCombat",_isInCombaStatus);

                StartCoroutine(Invincible());
                _isWalk=false;
                _isInCombaStatus=true;

                 
                //StartCoroutine(Freeze());
                if(health<=0)
                    Died();
            }
        }

        public virtual void Died(){
            Destroy(gameObject);
        }

      
        private IEnumerator Freeze(){
            _isWalk = false;
            _animator.SetBool("InCombat",true);
            yield return new WaitForSeconds(5f);
            _animator.SetBool("InCombat",false);
            _isWalk = true;
        }

        private IEnumerator Invincible(){
            _isCanTakeDamage = false;
             yield return new WaitForSeconds(0.5f);
             _isCanTakeDamage = true;
        }

        #endregion 


        #region  Movment
        
        private void Movment(){
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _targetMove[_currentTarget].position, step);

            if(Vector2.Distance(transform.position, _targetMove[_currentTarget].position)<0.5f)
                StartCoroutine(Wait());

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


        #endregion
    }
}
