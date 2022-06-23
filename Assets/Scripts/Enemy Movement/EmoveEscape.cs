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
       _transform.position -= (VectorSinY(Player.PlayerTransform.position) - VectorSinY(_transform.position)).normalized * _speed * Time.deltaTime;
    }

    Vector3 VectorSinY(Vector3 vec){
        return new Vector3(vec.x, 0f, vec.z);
    }

}
