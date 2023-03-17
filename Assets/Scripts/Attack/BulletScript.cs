using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Cinemachine;

public class BulletScript : MonoBehaviour
{
    CinemachineImpulseSource _impulseSource;
    public float damage;

    [SerializeField] private ParticleSystem _explosion;
    private float _lifeSpan = 3;
    public float lifeSpan
    {
        set => _lifeSpan = value;
    }

    private float _timer = 0;

    private void OnEnable()
    {
        _timer = 0;
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        if (_timer > _lifeSpan) 
        {
            Death();
            Debug.Log("Died Naturally");
        }

        _timer += Time.deltaTime;
    }

    private void Death()
    {
        ParticleSystem part = Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(part.gameObject, part.main.startLifetime.constant);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _impulseSource.GenerateImpulse();
        Death();
        Debug.Log("I have hit something");
    }
}
