using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {
    protected float baseDMG;
    protected abstract void EntityAttack();
}
