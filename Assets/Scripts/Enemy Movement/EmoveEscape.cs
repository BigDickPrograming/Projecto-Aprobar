using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoveEscape : IEMovement{ 
    float _speed;
    Transform _transform;
    Transform _target;
    public EmoveEscape(Transform transform, Transform target, float speed = 0.5f){
        _transform = transform;
        _target = Player.PlayerTransform;
        _speed = speed;
        
    }
    
    public void Emovement(){
      _transform.position -= (Player.PlayerTransform.position - _transform.position).normalized * _speed * Time.deltaTime;
       Debug.Log("estoy escapando");
       Debug.Log(Player.PlayerTransform.position);
    }
}
