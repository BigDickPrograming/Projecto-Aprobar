using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    [SerializeField]
    float _life;
  /*  protected virtual void Death(){
        instantiateCoin();
    }
    */
    public virtual void Death(){ //public solo para debuggear
        instantiateCoin();
    }
    public virtual void Damage(float dmg){
        _life -= dmg;
        if (_life <= 0)
            Death();
    }

    void instantiateCoin(){
        int rand = Random.Range(1, 101);
        if(rand <= 75){
            var c = CoinFactory.Instance.pool.GetObject();
            c.transform.position = transform.position;
            c.transform.forward = Vector3.forward;
        }
    }

    protected virtual void Reset(){}
}
