using System.Collections;
using System.Collections.Generic;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //private static InputManager _instance;

    ////public static InputManager Instance
    ////{
    ////    get => _instance;
    ////}
    ///
    Controls _controls;
    [SerializeField] Vector2 _movementInput;
    private float _verticalInput;
    private float _horizontalInput;
    public bool _isShoot = false;
    public bool IsShoot
    {
        get => _isShoot;
        set { _isShoot = value; }
    }

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Gameplay.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _controls.Gameplay.Fire.performed += HandleFireInput;
            _controls.Enable();
        }
    }
    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    private void HandleMovementInput()
    {
        _verticalInput = _movementInput.y;
        _horizontalInput = _movementInput.x;
    }

    private void HandleFireInput(CallbackContext ctx) 
    {
        _isShoot = true;
    }
}
