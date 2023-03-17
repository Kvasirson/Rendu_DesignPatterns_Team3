using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISet<T>
{
    public void Set(T value);
}

public class Reference<T> : ScriptableObject, ISet<T>
{
    private T reference;
    
    public T Value { get => reference; set => reference = value; }
    
    void ISet<T>.Set(T value)
    {
        reference = value;
    }
}
