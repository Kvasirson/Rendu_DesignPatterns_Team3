using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInjector))]
public class PlayerManager : MonoBehaviour
{
    InputManager _inputManager;
    PlayerMovement _playerMovement;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputManager.HandleAllInputs();
        _playerMovement.HandleMovement();
    }
}
