using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float Life;
    public int Attack;
    
    SerializeField _life;
    public virtual void Death(){
    //destroy();
    }
    public void attack(){
    
    }
  
    public virtual void Damage(float dmg){
        Life -= dmg;
        if (Life <= 0)
            Death();

    }
    public void SpecialAttack(){
        
    }

}
