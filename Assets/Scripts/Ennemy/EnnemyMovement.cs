using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public enum STATE
{
    PATROL,
    CHASE,
    NEUTRAL
}
public class EnnemyMovement : MonoBehaviour
{
    private STATE state = STATE.NEUTRAL;
    public void setEnnemyState(STATE newState) { state = newState; }

    private Transform _player;
    private Transform _target;
    [SerializeField,Range(1,10)] private float _speed;
    [SerializeField] Transform _patern;
    private List<Transform> _paternTargets;
    Rigidbody2D _rigidbody;
    int Paternindex = 0;

    private void Start()
    {
        _player = FindObjectOfType<PlayerManager>().transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        LoadPatern();
    }
    private void LoadPatern()
    {
        foreach (Transform t in _patern)
        {
            _paternTargets.Add(t);
        }
        _target = _paternTargets[Paternindex];
    }
    public void HandleAllMovement()
    {
        switch(state)
        {
            case STATE.PATROL:
                HandlePatrolMovement();
            break;

            case STATE.CHASE:
                HandleChaseMovement();
            break;
                    
            case STATE.NEUTRAL:

            break;

            default:

            break;
        }
    }
    private void HandlePatrolMovement()
    {
        Vector2 Direction = Vector2.zero;
        float Distance = Vector2.Distance(_target.position, transform.position);
        if (Distance <= 0.3f)
        {
            SwitchPaternTarget();
        }
        Direction = _target.position - transform.position;
        Direction.Normalize();
        //_rigidbody.AddForce(Direction * _speed);
        transform.Translate(Direction * _speed * 0.05f);
    }

    private void HandleChaseMovement()
    {
        Vector2 Direction = Vector2.zero;
        Direction = _player.position - transform.position;
        Direction.Normalize();
        //_rigidbody.AddForce(Direction * _speed);
        transform.Translate(Direction * _speed * 0.05f);
    }


    public void FindClosestPaternTarget()
    {
        float currentClosest = Vector2.Distance(_target.position, transform.position);
        foreach (Transform t in _patern)
        {
            if (Vector2.Distance(t.position,transform.position) < currentClosest)
            {
                _target = t;
            }
         } 
    }

    private void SwitchPaternTarget()
    {
        if(_target != _paternTargets[_paternTargets.Count-1])
        {
            Paternindex++;
        }
        else
        {
            Paternindex = 0;
        }
        _target = _paternTargets[Paternindex];
    }

}
