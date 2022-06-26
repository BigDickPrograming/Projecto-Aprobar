using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    [SerializeField]
    protected float _life;
    float maxHp;
    AudioSource audio;
    /*  protected virtual void Death(){
        instantiateCoin();
    }
    */
    public virtual void Death(){ //public solo para debuggear
        instantiateCoin();
    }
    public virtual void Damage(float dmg){
        _life -= dmg;
        audio.Play();
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
    public virtual void Heal(params object[] p){
        float ammount = (float) p[0];
        if (_life + ammount > maxHp){
            _life = maxHp;
            return;
        }
        _life += ammount;
    }
    protected virtual void Reset(){}

    private void Start(){
        maxHp = _life;
    }
}