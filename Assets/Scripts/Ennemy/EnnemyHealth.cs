using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    [SerializeField] private UnityEvent TakeDamageEvent;
    [SerializeField] private GameObject _ennemyRender;

    private void Reset()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;

        TakeDamageEvent.AddListener(EffectHit);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
            //TakeDamage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
    /// When Ennemy takes damage call effect for hit or die
    /// </summary>
    public void EffectHit()
    {
        if (_currentHealth <= 0)
            DieEffect();
        else
            GetHitEffect();
    }

    /// <summary>
    /// Ennemy render enable and disable for effect hit
    /// </summary>
    private void GetHitEffect()
    {
        if (!_ennemyRender)
            return;

        StartCoroutine(GetHit());

        IEnumerator GetHit()
        {
            for (int i = 0; i < 3; i++)
            {
                _ennemyRender.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                _ennemyRender.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private void DieEffect()
    {
        Destroy(gameObject);
    }

}
