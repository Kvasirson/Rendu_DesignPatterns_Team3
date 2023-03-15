using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    [SerializeField] private UnityEvent TakeDamageEvent;

    private Action LooseLife;

    private void Reset()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;

        TakeDamageEvent.AddListener(UpdateLife);
    }
    
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        
        TakeDamageEvent.Invoke();
    }

    private void UpdateLife()
    {
        LooseLife = _currentHealth <= 0 ? GetHitEffect : DieEffect;

        LooseLife();
    }

    private void GetHitEffect()
    {
        
    }

    private void DieEffect()
    {
        
    }
}
