using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDecorator : MonoBehaviour{
      Powerupp mypower = new HealingPowerupp();         
      public void StackEfect(){
             mypower = new HealEfects(mypower);
             mypower.Power();
             Debug.Log($"descripcion del poder: {mypower.GetPowerDescription()} - curacion: {mypower.Amount()}" );
      }
      
}
