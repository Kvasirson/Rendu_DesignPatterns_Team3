using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private PlayerReference _playerReference;
    
    private void Start()
    {
        Debug.Log(_playerReference.Instance.name);
    }
}
