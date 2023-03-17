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
    [SerializeField] private GameObject _playerRender;

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
            Dying();
        else
            GetHitEffect();
    }

    /// <summary>
    /// Player render enable and disable for effect hit
    /// </summary>
    private void GetHitEffect()
    {
        if (!_playerRender)
            return;
        
        StartCoroutine(GetHit());
        
        IEnumerator GetHit()
        {
            for (int i = 0; i < 3; i++)
            {
                _playerRender.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                _playerRender.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    /// <summary>
    /// Make effect for die
    /// </summary>
    private void DieEffect()
    {
        
    }
    
    /// <summary>
    /// Die effect and call Lose method from GameManager
    /// </summary>
    private void Dying()
    {
        DieEffect();
        
        GameManager.Instance.Lose();
    }
}
