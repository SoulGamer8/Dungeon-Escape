using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamageable
{

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private void Start() {
        _maxHealth = _currentHealth;
    }
    public void Heal(int health){
        _currentHealth += health;
        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth-=damage;
        if(_currentHealth <=0)
            Deth();
    }

    private void Deth()
    {
        Debug.Log("You die");
    }
}
