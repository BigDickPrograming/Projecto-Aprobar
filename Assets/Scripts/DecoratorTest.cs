using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorTest : MonoBehaviour
{
    private void Awake() {
         Powerupp mypower = new HealingPowerupp();
        
          
          mypower = new HealEfects(mypower);
          mypower = new HealEfects(mypower);
          mypower = new HealEfects(mypower);
          mypower = new HealEfects(mypower);
          mypower = new HealEfects(mypower);
          mypower = new HealEfects(mypower);
    

        Debug.Log($"descripcion del poder: {mypower.GetPowerDescription()} - curacion: {mypower.Amount()}" );
        mypower.Power();
    }
}
