using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

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
        for (int i = 0; i < ObjectPool.Count; i++)
        {
            if (!ObjectPool[i].activeInHierarchy)
            {
                ObjectPool[i].SetActive(true);
                return ObjectPool[i];
            }
        }
        GameObject PolledBullet = Instantiate(_prefab, transform);
        ObjectPool.Add(PolledBullet);
        return PolledBullet;
    }

    public void Release(GameObject gameobj)
    {
        Destroy(gameobj);
    }
}