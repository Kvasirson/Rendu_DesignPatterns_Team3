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
    [SerializeField]
    private Pool m_bulletPool;

    private Transform _nozzleTransform;
    private InputManager _inputManager;

    [SerializeField]
    private float m_lifeSpan = 1f;
    [SerializeField]
    private float m_damage = 10f;
    [SerializeField]
    private float m_force = 10f;

    [SerializeField]
    private ParticleSystem _muzzleFlash;
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
        if (_inputManager.shootMode == InputManager.ShootMode.PISTOL)
        {
            GameObject _bulletObj = m_bulletPool.Get();
            _bulletObj.transform.position = _nozzleTransform.position;
            Vector3 direction = m_aim.position - _bulletObj.transform.position;

            _bulletObj.GetComponent<Rigidbody2D>().velocity = new Vector3(direction.x, direction.y).normalized * m_force;
            _bulletObj.GetComponent<BulletScript>().lifeSpan = m_lifeSpan;
            _bulletObj.GetComponent<BulletScript>().damage = m_damage;
        }
        else if(_inputManager.shootMode == InputManager.ShootMode.SHOTGUN)
        {
            GameObject _bulletObj1 = m_bulletPool.Get();
            GameObject _bulletObj2 = m_bulletPool.Get();
            GameObject _bulletObj3 = m_bulletPool.Get();

            _bulletObj1.transform.position = _nozzleTransform.position;
            _bulletObj2.transform.position = _nozzleTransform.position;
            _bulletObj3.transform.position = _nozzleTransform.position;

            Vector3 direction = m_aim.position - _bulletObj1.transform.position;
            
            _bulletObj1.GetComponent<Rigidbody2D>().velocity = new Vector3(direction.x, direction.y).normalized * m_force;
            _bulletObj1.GetComponent<BulletScript>().lifeSpan = m_lifeSpan / 3f;
            _bulletObj1.GetComponent<BulletScript>().damage = m_damage;

            direction = Quaternion.AngleAxis(10f, Vector3.forward) * direction;
            
            _bulletObj2.GetComponent<Rigidbody2D>().velocity = new Vector3(direction.x, direction.y).normalized * m_force;
            _bulletObj2.GetComponent<BulletScript>().lifeSpan = m_lifeSpan / 3f;
            _bulletObj2.GetComponent<BulletScript>().damage = m_damage;
            
            direction = Quaternion.AngleAxis(-20f, Vector3.forward) * direction;

            _bulletObj3.GetComponent<Rigidbody2D>().velocity = new Vector3(direction.x, direction.y).normalized * m_force;
            _bulletObj3.GetComponent<BulletScript>().lifeSpan = m_lifeSpan / 3f;
            _bulletObj3.GetComponent<BulletScript>().damage = m_damage;
        }

        _muzzleFlash.Play();
    }
}
