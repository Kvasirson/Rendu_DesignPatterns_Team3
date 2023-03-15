using System.Collections;
using System.Collections.Generic;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Controls _controls;
    [SerializeField] Vector2 _movementInput;
    private float _verticalInput;
    private float _horizontalInput;

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
    
    }
}
