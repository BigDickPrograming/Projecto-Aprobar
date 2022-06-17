using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerDecorator : Powerupp
{
   protected Powerupp _power;

   public PowerDecorator(Powerupp power){
    _power = power;
   }
}