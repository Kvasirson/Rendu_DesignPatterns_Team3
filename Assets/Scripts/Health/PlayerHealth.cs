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

    private void Reset()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;

        TakeDamageEvent.AddListener(EffectHit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            TakeDamage();
    }

    public float GetHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    
    /// <summary>
    /// Reduce health of Player and call event
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage = 10)
    {
        damage = MathF.Abs(damage);
        
        _currentHealth -= damage;
        
        TakeDamageEvent.Invoke();
    }

    /// <summary>
    /// When Player takes damage call effect for hit or die
    /// </summary>
    public void EffectHit()
    {
        if (_currentHealth <= 0)
            DieEffect();
        else
            GetHitEffect();
    }

    private void GetHitEffect()
    {
        
    }

    private void DieEffect()
    {
        
    }
    
    public void Test()
    {
        Debug.Log("Test from PlayerHealth");
    }
}
