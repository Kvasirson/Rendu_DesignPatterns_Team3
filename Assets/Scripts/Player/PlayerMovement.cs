using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager _inputManager;
    Rigidbody2D _playerRigidbody;
    Vector2 _moveDirection;
    [SerializeField, Range(1,10)] private float _movementSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void HandleMovement()
    {
   
        _moveDirection = _inputManager.GetMovementInput();
        _moveDirection.Normalize();
        _moveDirection *= _movementSpeed;
        Vector2 movementVelocity = Vector2.zero;
        movementVelocity += _moveDirection;
        _playerRigidbody.velocity = new Vector3(movementVelocity.x, movementVelocity.y);

    }
}
