using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPowerupp : Powerupp{
  
  public float amount;
 
 public HealingPowerupp(){
    _description = "Healing Power up";
      amount = _amount;
   }
   
public override string GetPowerDescription(){
    return _description;
}
public override float Amount(){
    return amount;
    
}
public override void Power(){
  //EventManager.TriggerEvent(EVENT.GAIN_HP, amount);
  return;
}
}