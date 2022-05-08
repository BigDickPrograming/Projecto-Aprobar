using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField] protected float baseDMG = 0;
    Entity entity;
    protected void EntityAttack(){
        entity.Damage(baseDMG);
    }

    private void OnTriggerEnter(Collider other) {
        entity = other.GetComponentInParent<Entity>();
        if(entity != null){
            //Debug.Log("Name: " + entity.name);
            EntityAttack();
        }
    }

    private void OnTriggerExit(Collider other) {
        entity = null;
    }
}