using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private int _maxHealth;

    [SerializeField] private float _timeInvincible;
    private bool _isCanTakeDamage=true;
    private int _currentHealth;

    private void Start() {
        _currentHealth = _maxHealth;
        UpdateUI();
    }
    public void Heal(int health){
        _currentHealth += health;
        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        if(_isCanTakeDamage){
            _currentHealth-=damage;
            UpdateUI();
            if(_currentHealth <=0)
                Deth();
            StartCoroutine(TimeInvincible());
        }
    }

    private void UpdateUI(){
        _healthBar.fillAmount = _currentHealth;
    }

    private void Deth()
    {
        Debug.Log("You die");
    }

    private IEnumerator TimeInvincible(){
        _isCanTakeDamage =false;
        yield return new WaitForSeconds(_timeInvincible);
        _isCanTakeDamage =true;
    }
}
