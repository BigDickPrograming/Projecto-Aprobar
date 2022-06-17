using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerup : Powerupp
{ 
   public AttackPowerup(){
    _description = "Attack Powerupp";
    _amount = 5f;

   }

public override string GetPowerDescription(){
    return _description;
}
public override float Amount(){
    return _amount;
}
public override void Power(){
    //efecto del power up
    return;
    
}
}
