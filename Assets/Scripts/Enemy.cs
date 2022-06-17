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
    protected IEMovement _previousBehavior;
    public ParticleSystem Particle;
    public bool DoingBehaviour = false;
    void Awake(){
        _Escape = new EmoveEscape(transform, Player.PlayerTransform, _speed);
        _Chase = new EmoveTarget(transform, Player.PlayerTransform, _speed);
        MyCurrentBehavior = _Chase;
    }
    void Update(){
       if(DoingBehaviour) MyCurrentBehavior?.Emovement();    
    }
    public override void Death(){
        ParticleDeath();
        base.Death();    
    }
    private void OnTriggerEnter(Collider other){
        DoingBehaviour = true;
    }
    private void OnTriggerExit(Collider other) {
       DoingBehaviour = false;
    }    
    public void ParticleDeath(){    
        Instantiate(Particle, transform.position,Quaternion.identity);

    }
}


