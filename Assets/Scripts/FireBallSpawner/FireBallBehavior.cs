using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{
    private Vector2 _direction;
    private float _speed;
    private float _damage;
    [SerializeField] private ParticleSystem _TrailParticleSystem;
    [SerializeField] private ParticleSystem _ExplosionparticleSystem;
    [SerializeField] private SpriteRenderer _sr;
    private Animator _animator;
    public void InitFireBall(Vector2 direction, float speed,float damage)
    {
        _animator.Play("Idle");
        _sr.enabled = true;
        _TrailParticleSystem.Play();
        _ExplosionparticleSystem.Stop();
        _direction = direction;
        _speed = speed;
        _damage = damage;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        PlayerHealth _hp = collision.gameObject.GetComponent<PlayerHealth>();
        if (_hp)
        {
            _hp.TakeDamage(_damage);
        }
        StartCoroutine(explosion());
    }
    private void Death()
    {
        gameObject.SetActive(false);
    }

    IEnumerator explosion()
    {
        _animator.Play("lightsOut");
        _speed = 0;
        _TrailParticleSystem.Stop();
        _sr.enabled = false;
        _ExplosionparticleSystem.Play();
        yield return new WaitForSeconds(1);
        Death();
    }
}
