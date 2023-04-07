using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighningGeneratorBehavior : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _tickSpeed;
    private float _currenTickTime = 0;
    PlayerHealth hp;
    bool active = false;
    private void Start()
    {
        _currenTickTime = _tickSpeed;
        hp = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if (!active)
            return;

        _currenTickTime += Time.deltaTime;

        if (_currenTickTime >= _tickSpeed)
        {
            _currenTickTime -= _tickSpeed;
            Debug.Log("damage");
            hp.TakeDamage(_damage);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        active = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        _currenTickTime = _tickSpeed;
        active = false;
    }
}
