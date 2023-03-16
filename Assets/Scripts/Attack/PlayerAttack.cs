using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bulletObj;
    [SerializeField]
    private Transform m_aim;

    private Transform _nozzleTransform;
    private InputManager _inputManager;

    [SerializeField]
    private float m_lifeSpan = 1f;
    [SerializeField]
    private float m_damage = 10f;
    [SerializeField]
    private float m_force = 10f;

    private void Start()
    {
        _inputManager = GetComponentInParent<InputManager>();
        _nozzleTransform = transform.GetChild(0).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = m_aim.position - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, rotZ);

        if (_inputManager.IsShoot)
        {
            _inputManager.IsShoot = false;
            Shoot();
        }
    }

    void Shoot() 
    {
        GameObject _bulletObj = Instantiate(m_bulletObj, _nozzleTransform.position, Quaternion.identity);
        Vector3 direction = m_aim.position - _bulletObj.transform.position;
        _bulletObj.GetComponent<Rigidbody2D>().velocity = new Vector3(direction.x, direction.y).normalized * m_force;
        _bulletObj.GetComponent<BulletScript>().lifeSpan = m_lifeSpan;
        _bulletObj.GetComponent<BulletScript>().damage = m_damage;
    }
}
