using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnnemyAggro : MonoBehaviour
{
    [SerializeField,Range(1,10)] private float _zoneRadius;
    [SerializeField]LayerMask _layerMask;
    EnnemyMovement _ennemyMovement;
    private Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        _ennemyMovement = GetComponent<EnnemyMovement>();
        _playerTransform = FindObjectOfType<PlayerManager>().transform;
        ChangeZoneRadius(_zoneRadius);
    }

    public void LookForPlayer()
    {
        Vector2 Direction = _playerTransform.position -transform.position;
        Direction.Normalize();
        if (Vector2.Distance(transform.position, _playerTransform.position) < _zoneRadius)
        {
            if (Physics2D.Raycast(transform.position, Direction, _zoneRadius, _layerMask))
            {
                _ennemyMovement.setEnnemyState(STATE.CHASE);
            }
            else
            {
                _ennemyMovement.setEnnemyState(STATE.PATROL);
                _ennemyMovement.FindClosestPaternTarget();
            }

        }
    }

    private void ChangeZoneRadius(float newRadius)
    {
        _zoneRadius = newRadius;
    }

}
