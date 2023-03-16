using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bulletObj;

    private InputManager _inputManager;

    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputManager.IsShoot)
        {
            Shoot();
            _inputManager.IsShoot = false;
        }
    }

    void Shoot() 
    {
        GameObject _bulletObj = Instantiate(m_bulletObj, transform.position + new Vector3(1.0f, 0.0f, -0.1f), Quaternion.Angle(transform.position, Input.mousePosition));//(transform.position - Input.mousePosition).normalized);
        
        _bulletObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.1f,0));
    }
}
