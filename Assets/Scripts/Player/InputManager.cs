using System;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //private static InputManager _instance;

    //public static InputManager Instance
    //{
    //    get => _instance;
    //}



    Controls _controls;
    [SerializeField] Vector2 _movementInput;
    public Vector2 GetMovementInput(){ return _movementInput;}
    private float _verticalInput;
    private float _horizontalInput;
    public ShootMode shootMode = ShootMode.PISTOL;
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
            _controls.Gameplay.ChangeWeapon.performed += HandleSwitchWeapon;
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
    private void HandleSwitchWeapon(CallbackContext ctx)
    {
        int mode = Convert.ToInt32(ctx.control.name);
        if (mode == 1)
        {
            shootMode = ShootMode.PISTOL;
        } else if (mode == 2)
        {
            shootMode = ShootMode.SHOTGUN;
        }
    }
    
    
    public enum ShootMode
    {
        PISTOL,
        SHOTGUN
    }
}
