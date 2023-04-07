using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInjector : MonoBehaviour
{
    [SerializeField] private Entity _e;
    [SerializeField] private PlayerReference _playerReference;
    
    ISet<Entity> RealRef => _playerReference;

    private void Awake()
    {
        RealRef.Set(_e);
    }
}
