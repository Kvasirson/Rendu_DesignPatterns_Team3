using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{
    private Vector2 _direction;
    private float _speed;
    private float _damage;
    private ParticleSystem _ExplosionparticleSystem;
    private SpriteRenderer _sr;
    public void InitFireBall(Vector2 direction, float speed)
    {
        _direction = direction;
        _speed = speed;
    }

    private void Start()
    {
        _ExplosionparticleSystem = GetComponent<ParticleSystem>();
        _sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth _hp = collision.gameObject.GetComponent<PlayerHealth>();
        if (_hp)
        {
            _hp.TakeDamage(_damage);
        }
        Death();
    }
    private void Death()
    {
        gameObject.SetActive(false);
    }

    IEnumerator explosion()
    {
        _sr.enabled = true;
        _ExplosionparticleSystem.Play();
        yield return new WaitForSeconds(1);
        Death();
    }
}
