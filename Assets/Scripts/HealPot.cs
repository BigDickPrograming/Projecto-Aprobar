using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPot : Entity {
      [SerializeField] HealingDecorator decorator;
    public override void Death(){
         Destroy(gameObject);
         decorator.StackEfect();
         
    }
}
