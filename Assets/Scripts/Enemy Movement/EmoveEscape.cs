using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoveEscape : IEMovement{ 
    protected float _speed;
    protected Transform _transform;
    protected Transform _target;
    public EmoveEscape(Transform transform, Transform target, float speed = 1.5f){
        _transform = transform;
        //_target = Player.PlayerTransform;
        _target = playerManager.PlayerTransform;
        _speed = speed;
        
    }
    
    public void Emovement(){
      _transform.position -= (playerManager.PlayerTransform.position - _transform.position).normalized * _speed * Time.deltaTime;
        //_transform.position -= (Vector3.zero)*_speed * Time.deltaTime;
       
        //Debug.Log(_target.position + _transform.position);
       /* 
         Vector3 dir = _transform.position - _target.position;
        _transform.Translate(dir * _speed * Time.deltaTime);
        */
    }
}
