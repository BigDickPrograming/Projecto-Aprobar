using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Entity {
    public override void Death(){
        EventManager.TriggerEvent(EVENT.WINGAME);
    }
}
