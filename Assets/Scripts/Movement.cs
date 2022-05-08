using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour {
    [SerializeField] float speed = 5;
    [SerializeField] Controller controller;
    Vector3 dir;
    Vector3 _myForward = Vector3.zero;
    Vector3 _lastPos;
    private void Update(){
        dir = controller.GetDir();
        transform.position += dir * speed * Time.deltaTime;
        if(dir != Vector3.zero){
            _myForward = dir;
            AnimatorManager.Instance.setIsWalking(true);
            float sp = (Vector3.Distance(_lastPos, transform.position) / Time.deltaTime)/speed;
            AnimatorManager.Instance.setSpeed(sp);
        }
        else{
            AnimatorManager.Instance.setIsWalking(false);
        }
        transform.forward = _myForward;
        _lastPos = transform.position;
    }
    private void Start() {
        _lastPos = transform.position;
    }
}
