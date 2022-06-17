using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField] protected float baseDMG = 0;
    Entity entity;
    protected virtual void EntityAttack(){
        entity.Damage(baseDMG);
    }

    private void OnTriggerEnter(Collider other) {
        entity = other.GetComponentInParent<Entity>();
        if(entity != null){
            Debug.Log("Name: " + entity.name);
            EntityAttack();
            entity = null;
        }
    }

    private void OnTriggerExit(Collider other) {
        entity = null;
    }
}