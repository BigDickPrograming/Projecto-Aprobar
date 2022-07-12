using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField] protected float baseDMG = 0;
    Entity entity;
    bool isAttacking = false;
    protected virtual void EntityAttack(){
        entity.Damage(baseDMG);
    }

    private void OnTriggerEnter(Collider other) {
        entity = other.GetComponentInParent<Entity>();
        isAttacking = true;
        if(other != null){
            Debug.Log("Name: " + entity.name);
            EntityAttack();
            //StartCoroutine(attackOnStay());
            entity = null;
        }
    }

    private void OnTriggerExit(Collider other) {
        entity = null;
        isAttacking = false;
    }
    
    IEnumerator attackOnStay(){
        while(isAttacking){
            EntityAttack();
            yield return new WaitForSeconds(1f);
        }
    }
}