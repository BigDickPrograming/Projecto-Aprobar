using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBullet : MonoBehaviour {
    private Vector3 _velocity;

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }

    public void ApplyForce(Vector3 force){
        _velocity += force;
    }

    private void Update() {
        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }
    private void Start() {
        Destroy(gameObject, 3f);
    }
}