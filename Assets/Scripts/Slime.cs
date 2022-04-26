using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EntityPrototype {
    int _numSlime = 0;
    
    #region Builder
    public Slime SetPosition(float x = 0, float y = 0, float z = 0){
        transform.position = new Vector3(x, y, z);
        return this;
    }

    public Slime SetScale(float x = 1, float y = 1, float z = 1){
        transform.localScale = new Vector3(x, y, z);
        return this;
    }

    public override EntityPrototype Clone(){
        var res = SlimeFactory.Instance.pool.GetObject();
        float espacio = 0.5f/_numSlime;
        res.SetPosition(transform.localPosition.x + Random.Range(-espacio, espacio)
                , transform.localPosition.y, transform.localPosition.z + Random.Range(-espacio, espacio))
            .SetScale(transform.localScale.x - 0.25f, transform.localScale.y - 0.25f, transform.localScale.z - 0.25f);
        res._numSlime = _numSlime;
        return res;
    }

    public override void Death(){
        //base.Death();
        _numSlime++;
        if(_numSlime <= 2){
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
