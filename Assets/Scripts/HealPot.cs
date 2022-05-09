using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPot : Entity {
    public override void Death(){
        EventManager.TriggerEvent(EVENT.GAIN_HP, 25f);
        Destroy(gameObject);
    }
}
