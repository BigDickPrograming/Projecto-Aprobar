using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEfects : PowerDecorator
{
    public HealEfects(Powerupp power) : base(power){
         
    }
    public override string GetPowerDescription(){
        return _power.GetPowerDescription() + ",  + 10 a curacion ";
    }
    public override float Amount(){
        return _power.Amount() + 10f;
    }
    public override void Power(){
         EventManager.TriggerEvent(EVENT.GAIN_HP , Amount());
        return;
    }

   
    



}