using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {
    [SerializeField]
    protected float _speed = 5;
    [SerializeField]
    protected Transform _target;
    public IEMovement MyCurrentBehavior;
    protected IEMovement _Escape;
    protected IEMovement _Chase;
    IEMovement _previousBehavior;
    public ParticleSystem Particle;
    void Awake(){
        _Escape = new EmoveEscape(transform, playerManager.PlayerTransform, _speed);
        _Chase = new EmoveTarget(transform, playerManager.PlayerTransform, _speed);
        MyCurrentBehavior = null;
        _previousBehavior = _Chase;
    }
    void Update(){
        MyCurrentBehavior?.Emovement();
        Debug.Log("mi transform es " + transform);
        Debug.Log("mi velosida es " + _speed);
        Debug.Log("mi behavior es " + MyCurrentBehavior);
    }
    public override void Death(){
        ParticleDeath();
        MyCurrentBehavior = _Escape;
        base.Death();    
    }
    private void OnTriggerEnter(Collider other){
        MyCurrentBehavior = _previousBehavior;
    }
    private void OnTriggerExit(Collider other) {
        _previousBehavior = MyCurrentBehavior;
        MyCurrentBehavior = null;
    }    
    public void ParticleDeath(){    
        Instantiate(Particle, transform.position,Quaternion.identity);

    }
}


