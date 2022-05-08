using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity{
    [SerializeField]
     protected float _speed = 5;
    [SerializeField]
    protected Transform _target;
    public IEMovement MyCurrentBehavior;
    protected IEMovement _Escape;
    protected IEMovement _Chase;
     void Awake(){
        _Escape = new EmoveEscape(transform, _target, _speed);
        _Chase = new EmoveTarget(transform, _target, _speed);
        MyCurrentBehavior = _Chase;
        
    }
    void Update(){
        MyCurrentBehavior?.Emovement();
        //Debug.Log("mi transform es " + transform);
        //Debug.Log("mi velosida es " + _speed);
        //Debug.Log("mi behavior es " + MyCurrentBehavior);
    }
    public override void Death(){
     //Debug.Log(MyCurrentBehavior);
     base.Death();    
    }

}

