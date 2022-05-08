using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakeable : Entity {
    public override void Death(){
        base.Death();
        Destroy(gameObject);
    }
}
