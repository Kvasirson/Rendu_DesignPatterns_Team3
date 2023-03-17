using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    PlayerHealth _playerHealth;

    // Start is called before the first frame update
    private float _currentTickTime = 0;
    [SerializeField] private float _nextTickTime = 0.5f;
    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerManager>().transform.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        HandleDamage();
    }

    private void HandleDamage()
    {
        _currentTickTime += Time.deltaTime;

        if (_currentTickTime >= _nextTickTime)
        {
            _currentTickTime -= _nextTickTime;
            _playerHealth.TakeDamage(_damage);
        }
    }
}
