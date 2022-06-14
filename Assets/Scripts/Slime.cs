using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy, IPrototype {
    int _numSlime = 0;  
    Transform playertarget = playerManager.PlayerTransform;
    #region Builder
    public Slime SetPosition(float x = 0, float y = 0, float z = 0){
        transform.position = new Vector3(x, y, z);
        return this;
    }
    public Slime setChase(Transform transform, Transform playertarget, float speed = 1f){
        _Chase = new EmoveTarget(transform, playertarget, _speed);
        return this;
    }
    public Slime setEscape(Transform transform, Transform playertarget, float speed = 2f){
        _Escape = new EmoveEscape(transform, playertarget, _speed);
        Debug.Log(_Escape);
        return this;
    }
    public Slime setCurrentBehavior(IEMovement behavior){
        MyCurrentBehavior = behavior; 
        //Debug.Log(MyCurrentBehavior);
        return this;
    }
    public Slime SetScale(float x = 1, float y = 1, float z = 1){
        transform.localScale = new Vector3(x, y, z);
        return this;
    }
    public IPrototype Clone(){
        var res = SlimeFactory.Instance.pool.GetObject();
        float espacio = 0.5f/_numSlime + 2f;
        res.SetPosition(transform.localPosition.x + Random.Range(-espacio, espacio)
                , transform.localPosition.y, transform.localPosition.z + Random.Range(-espacio, espacio))
            .SetScale(transform.localScale.x - 0.25f, transform.localScale.y - 0.25f, transform.localScale.z - 0.25f)
            .setChase(transform, playertarget, _speed)
            .setEscape(transform, playertarget, _speed)
            .setCurrentBehavior(_Escape);
            
        res._numSlime = _numSlime;
        return res;
    }
    public override void Death(){
        ParticleDeath();
        base.Death();
        _numSlime++;
        if(_numSlime <= 1){
            
            Clone();
            Clone();
            Clone();
            Clone();
            
        }
        SlimeFactory.Instance.ReturnSlime(this);
    }
    #endregion

    #region Factory
    protected override void Reset(){
        //base.Reset();
        _numSlime = 0;
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