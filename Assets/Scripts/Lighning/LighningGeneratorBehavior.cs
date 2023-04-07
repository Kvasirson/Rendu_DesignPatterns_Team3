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
    [SerializeField] private GameObject _capsule;
    private void Start()
    {
        _capsule.SetActive(false);
        _currenTickTime = _tickSpeed;
        hp = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if (!active)
            return;

        _capsule.transform.position = hp.transform.position;
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

        _capsule.SetActive(true);
        active = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        _currenTickTime = _tickSpeed;
        _capsule.SetActive(false);
        active = false;
    }
}
