using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : MonoBehaviour {
    [SerializeField] protected float baseDMG = 0;
    Entity entity;
    bool attacking = false;
    [SerializeField] Animator anim;
    int attackHash = Animator.StringToHash("Attack");
    [SerializeField] Transform golemTransform;
    IEnumerator Attack(){
        while(attacking){
            anim.SetTrigger(attackHash);
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }

    IEnumerator LookToPlayer(){
        while(attacking){
            golemTransform.LookAt(Player.PlayerTransform);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
    private void OnTriggerEnter(Collider other) {
        entity = other.GetComponentInParent<Entity>();
        if(entity != null){
            attacking = true;
            StartCoroutine(Attack());
            StartCoroutine(LookToPlayer());
        }
    }

    private void OnTriggerExit(Collider other) {
        attacking = false;
        entity = null;
    }
}