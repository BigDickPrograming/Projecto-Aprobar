using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour {
   
   public AudioSource playeraudio;
    public static AnimatorManager Instance {
        get {
            return _instance;
        }
    }
    static AnimatorManager _instance;
    public bool block;
    public bool isWalking;
    public bool attackEnabled = true;
    Animator anim;
    int attackHash = Animator.StringToHash("Attack");

    void Start(){
        anim = GetComponent<Animator>();
        _instance = this;
    }
    public void Attack(){
        if(attackEnabled){
            anim.SetTrigger(attackHash);
            attackEnabled = false;
            StartCoroutine(LateEnableAttack());
        }
    }
    IEnumerator LateEnableAttack(){
        yield return new WaitForSeconds(0.5f);
        attackEnabled = true;
    }

    public void setIsWalking(bool isWalking){
        anim.SetBool("IsWalking", isWalking);
    }
    public void setSpeed(float speed){
        anim.SetFloat("Speed", speed);
    }
}