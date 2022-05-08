using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
 public bool block;
 public bool isWalking;
 Animator anim;
 int attackHash = Animator.StringToHash("Attack");
  
  void Start(){
    anim = GetComponent<Animator>();
  }

    void Update(){
        
    }
    public void Attack(){
        anim.SetTrigger(attackHash);
        
    }
}