using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float damage;
    [SerializeField] private ParticleSystem _explosion;
    private float _lifeSpan = 3;
    public float lifeSpan
    {
        set => _lifeSpan = value;
    }

    private float _timer = 0;

    private void Start()
    {

    }

    void Update()
    {
        if (_timer > _lifeSpan) 
        {
            Death();
        }

        _timer += Time.deltaTime;
    }

    private void Death()
    {
        ParticleSystem part = Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(part, part.main.startLifetime.constant);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }
}
