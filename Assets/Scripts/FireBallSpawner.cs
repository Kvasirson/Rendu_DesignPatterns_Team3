using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : MonoBehaviour, IFactory
{
    public List<GameObject> ObjectPool { get; set; }

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private float m_startupCount;

    [SerializeField]
    private int _index = 0;

    [SerializeField] private float _timeBtwShots;
    private float _currentTime = 0;
    [SerializeField] private float _angleIncrement;
    private float _currentAngle = 0;
    [SerializeField] private float _FireBall_Speed;
    void Awake()
    {
        ObjectPool = new List<GameObject>();
        Warmup();
    }
    #region pool
    void Warmup()
    {
        for (int i = 0; i < m_startupCount; i++)
        {
            ObjectPool.Add(Instantiate(_prefab, transform));
            ObjectPool[i].SetActive(false);
        }
    }

    public GameObject Get()
    {
        _index += 1;
        if (ObjectPool.Count <= _index)
        {
            _index = 0;
        }
        ObjectPool[_index].SetActive(true);
        return ObjectPool[_index];
    }

    public void Release(GameObject gameobj)
    {
        Destroy(gameobj);
    }
    #endregion

    public void Update()
    {
        if (_currentTime < _timeBtwShots)
        {
            _currentTime += Time.deltaTime;
        }
        else
        {
            _currentTime -= _timeBtwShots;
            ShootFireBall();
            _currentAngle += _angleIncrement;
        }
    }

    void ShootFireBall()
    {
        GameObject _bulletObj1 = Get();
        _bulletObj1.transform.position = transform.localPosition;
        Vector2 direction1 = Quaternion.AngleAxis(_currentAngle, Vector3.forward) * Vector2.right;
        _bulletObj1.GetComponent<FireBallBehavior>().InitFireBall(direction1, _FireBall_Speed);

        GameObject _bulletObj2 = Get();
        _bulletObj2.transform.position = transform.localPosition;
        Vector2 direction2 = Quaternion.AngleAxis(_currentAngle, Vector3.forward) * -Vector2.right;
        _bulletObj2.GetComponent<FireBallBehavior>().InitFireBall(direction2, _FireBall_Speed);

        GameObject _bulletObj3 = Get();
        _bulletObj3.transform.position = transform.localPosition;
        Vector2 direction3 = Quaternion.AngleAxis(_currentAngle, Vector3.forward) * Vector2.up;
        _bulletObj3.GetComponent<FireBallBehavior>().InitFireBall(direction3, _FireBall_Speed);

        GameObject _bulletObj4 = Get();
        _bulletObj4.transform.position = transform.localPosition;
        Vector2 direction4 = Quaternion.AngleAxis(_currentAngle, Vector3.forward) * -Vector2.up;
        _bulletObj4.GetComponent<FireBallBehavior>().InitFireBall(direction4, _FireBall_Speed);
    }
}
