using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IFactory 
{
    public GameObject Get();
    public void Release(GameObject gameobj);
}

public class Pool : MonoBehaviour, IFactory
{
    public List<GameObject> ObjectPool { get; set; }

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private float m_startupCount;

    [SerializeField]
    private int _index = 0;

    void Awake()
    {
        ObjectPool = new List<GameObject>();
        Warmup();
    }

    void Warmup() 
    {
        for (int i = 0; i < m_startupCount; i++)
        {
            ObjectPool.Add(Instantiate(_prefab,transform));
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
}

//class Spawner : MonoBehaviour, IFactory
//{
//    [SerializeField]
//    private GameObject _prefab;
//    public GameObject Get()
//    {
//        return Instantiate(_prefab);
//    }

//    public void Release(GameObject gameobj)
//    {
//        Destroy(gameobj);
//    }
//}
