using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaEnemy : Entity
{
    [SerializeField]
     float _speed = 5;
    [SerializeField]
    Transform _target;

    IEMovement MyCurrentBehavior;
    IEMovement _Patrol;
    IEMovement _Chase;
    void Awake()
    {
        _Patrol = new EmovePatrol();
        _Chase = new EmoveTarget(transform, _target, _speed);
        MyCurrentBehavior = _Chase;
    }

    
    void Update()
    {
        MyCurrentBehavior?.Emovement();
    }
}
