using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISet<T>
{
    public void Set(T value);
}

public class Reference<T> : ScriptableObject, ISet<T>
{
    private T _instance;
    
    public T Instance { get => _instance; set => _instance = value;}
    
    void ISet<T>.Set(T value)
    {
        _instance = value;
    }
}
