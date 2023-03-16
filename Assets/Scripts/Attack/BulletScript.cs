using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float damage;

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
            Destroy(gameObject);
        }

        _timer += Time.deltaTime;
    }
}
