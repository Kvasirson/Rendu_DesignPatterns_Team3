using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private UnityEvent WinEvent;
    [SerializeField] private UnityEvent LoseEvent;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Win()
    {
        WinEvent?.Invoke();
    }
    
    public void Lose()
    {
        LoseEvent?.Invoke();
    }
}