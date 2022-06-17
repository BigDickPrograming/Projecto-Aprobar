using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerupp {

    protected string _description;
    protected float _amount;
    public abstract float Amount();
    public abstract string GetPowerDescription();
    public abstract void Power();
    
    

}
