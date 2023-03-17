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
        // init des components requis
        _ennemyMovement = GetComponent<EnnemyMovement>();
        _ennemyAggro = GetComponent<EnnemyAggro>();
    }

    void FixedUpdate()
    {
        //Appel des fonctions de base des components
        _ennemyAggro.LookForPlayer();
        _ennemyMovement.HandleAllMovement();
    }
}
