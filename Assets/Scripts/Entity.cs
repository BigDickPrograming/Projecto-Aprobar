using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float Life;
    public int Attack;

    SerializeField _life;
    public virtual void Death(){
        instantiateCoin();
    }
    public virtual void Damage(float dmg){
        Life -= dmg;
        if (Life <= 0)
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

}
