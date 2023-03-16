using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnnemyMovement))]
[RequireComponent(typeof(EnnemyHealth))]
[RequireComponent(typeof(EnnemyAggro))]
public class EnnemyManager : MonoBehaviour
{
    EnnemyMovement _ennemyMovement;
    EnnemyAggro _ennemyAggro;

    private void Awake()
    {
        _ennemyMovement = GetComponent<EnnemyMovement>();
        _ennemyAggro = GetComponent<EnnemyAggro>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _ennemyAggro.LookForPlayer();
        _ennemyMovement.HandleAllMovement();
     
    }
}
