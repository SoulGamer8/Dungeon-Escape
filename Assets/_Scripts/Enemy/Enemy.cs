using System.Collections;
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
        protected bool _isDead= false;

        [SerializeField] protected GameObject _diamondPrefab;
        [SerializeField] protected int _scoreForKill;
        protected Animator _animator;
        protected SpriteRenderer _spriteRender;

        protected Transform _playerTransform;

        protected virtual void Awake() {
                _animator =GetComponent<Animator>();
                _spriteRender = GetComponent<SpriteRenderer>();
        } 

        protected virtual void Update() {
            if(_isWalk==true && !_isInCombaStatus && _isDead == false)
                Movment();
            if(_isInCombaStatus == true && _isDead == false){
                Attack();
            }
        }

        protected virtual void Attack(){
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
                
            Vector3 direction = _playerTransform.transform.position - transform.position;
            FlipSprite(direction.x);

            if(Vector2.Distance(transform.position, _playerTransform.position)>5f){
                _isInCombaStatus=false;
                _isWalk=true;   
                _animator.SetBool("InCombat",_isInCombaStatus);    

                direction = _targetMove[_currentTarget].position - transform.position;
                FlipSprite(direction.x);
            }
        }


        #region Damage 
        
        public void TakeDamage(int damage)
        {
            if(_isDead == true)
                return;
            if(_isCanTakeDamage){
                health -= damage;
                
                _animator.SetTrigger("Hit");

                _isInCombaStatus=true;
                _animator.SetBool("InCombat",_isInCombaStatus);

                StartCoroutine(Invincible());
                _isWalk=false;

                if(health<=0)
                    Died();
            }
        }

        protected virtual void Died(){
            _animator.SetTrigger("Death");
            GameObject diamond =Instantiate(_diamondPrefab,transform.position,Quaternion.identity);
            diamond.GetComponent<Diamond>().SetScore(_scoreForKill);
            _isDead =true;
        }


        private IEnumerator Invincible(){
            _isCanTakeDamage = false;
             yield return new WaitForSeconds(0.5f);
             _isCanTakeDamage = true;
        }

        #endregion 


        #region  Movment
        
        protected virtual void Movment(){
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
            Vector3 direction = _targetMove[_currentTarget].position - transform.position;
            FlipSprite(direction.x);
        }


        private void FlipSprite(float direction){
           if(direction > 0)
                gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            else 
                gameObject.transform.rotation = Quaternion.Euler(0,180,0);
        }    


        #endregion
    }
}
