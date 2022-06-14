using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoveTarget : IEMovement{
    float _speed;
    Transform _transform;
    Transform _target;
    public EmoveTarget(Transform transform, Transform target, float speed = 2){
        _transform = transform;
         //target = playerManager._transform;
        _target = target;
        _speed = speed;
        //Debug.Log(_target);
    }
    public void Emovement(){
        _transform.position += (playerManager.PlayerTransform.position - _transform.position).normalized * _speed * Time.deltaTime;
    }   
}
