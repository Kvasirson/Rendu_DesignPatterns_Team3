using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnnemyMovement))]
[RequireComponent(typeof(EnnemyHealth))]
public class EnnemyManager : MonoBehaviour
{
    EnnemyMovement _ennemyMovement;

    private void Awake()
    {
        _ennemyMovement = GetComponent<EnnemyMovement>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _ennemyMovement.HandleMovement();
    }
}
