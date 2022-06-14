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
    Animator anim;
    int attackHash = Animator.StringToHash("Attack");

    void Start(){
        anim = GetComponent<Animator>();
        _instance = this;
    }
    public void Attack(){
        anim.SetTrigger(attackHash);
        
    }

    public void setIsWalking(bool isWalking){
        anim.SetBool("IsWalking", isWalking);
    }
    public void setSpeed(float speed){
        anim.SetFloat("Speed", speed);
    }
}