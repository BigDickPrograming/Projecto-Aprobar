using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy, IPrototype {
    int _numSlime = 0;  
    Transform playertarget = Player.PlayerTransform;
    #region Builder
    public Slime SetPosition(float x = 0, float y = 0, float z = 0){
        transform.position = new Vector3(x, y, z);
        return this;
    }/*
    public Slime setChase(Transform transform, Transform playertarget, float speed = 1f){
        _Chase = new EmoveTarget(transform, playertarget, _speed);
        return this;
    }*/
    public Slime setEscape(){
        MyCurrentBehavior = _Escape;
        return this;
    }
     public Slime setDoingBehaviour(){
        DoingBehaviour = false;
        return this;
    }
    public Slime setPreviousBehavior(IEMovement behavior){
        _previousBehavior = behavior;
        return this;
    }
    public Slime setCurrentBehavior(IEMovement behavior){
        MyCurrentBehavior = behavior; 
        return this;
    }
    public Slime SetScale(float x = 1, float y = 1, float z = 1){
        transform.localScale = new Vector3(x, y, z);
        return this;
    }

    public IPrototype Clone(){
        var res = Instantiate(this);
        float espacio = 0.5f/_numSlime + 4f;
        res.SetPosition(transform.localPosition.x + Random.Range(-espacio, espacio)
                , transform.localPosition.y, transform.localPosition.z + Random.Range(-espacio, espacio))
            .SetScale(transform.localScale.x - 0.25f, transform.localScale.y - 0.25f, transform.localScale.z - 0.25f)
            .setDoingBehaviour()
            .setEscape();
        res._numSlime = _numSlime;
        return res;
    }
    public override void Death(){
        ParticleDeath();
        _numSlime++;
        if(_numSlime <= 1){
            
            Clone();
            Clone();
            Clone();
            Clone();
            
        }
        SlimeFactory.Instance.ReturnSlime(this);
        base.Death();
    }
    #endregion

    #region Factory
    protected override void Reset(){
         //base.Reset();
        _life = 2;
    }
    public static void TurnOn(Slime s){
        s.Reset();
        s.gameObject.SetActive(true);
    }

    public static void TurnOff(Slime s){
        s.gameObject.SetActive(false);
    }
    #endregion
}