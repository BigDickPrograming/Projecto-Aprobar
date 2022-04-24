using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float Life;
    public int Attack;

    SerializeField _life;
    public virtual void Death(){

    }
    public virtual void Damage(float dmg){
        Life -= dmg;
        if (Life <= 0)
            Death();

    }


}
