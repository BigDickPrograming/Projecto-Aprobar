using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour {
    [SerializeField] protected float baseDMG = 0;
    Entity entity;
    protected virtual void EntityAttack(){
        entity.Damage(baseDMG);
    }

    private void OnTriggerEnter(Collider other) {
        entity = other.GetComponentInParent<Entity>();
        if(other != null){
            StartCoroutine(attackOnStay());
        }
    }

    private void OnTriggerExit(Collider other) {
        entity = null;
    }
    
    IEnumerator attackOnStay(){
        while(entity != null){
            EntityAttack();
            Debug.Log(entity);
            yield return new WaitForSeconds(1f);
        }
    }
}