using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour {
    [SerializeField] protected float baseBleedDMG = 1;
    Entity entity;
    bool bleeding = false;

    private void OnTriggerEnter(Collider other) {
        entity = other.GetComponentInParent<Entity>();
        if(other != null && !bleeding){
            Debug.Log("ataco");
            StartCoroutine(BleedDamage());
        }
    }
    
    IEnumerator BleedDamage(){
        bleeding = true;
        for(int i = 0; i < 10; i++){
            entity.Damage(baseBleedDMG);
            yield return new WaitForSeconds(0.5f); 
        }
        entity = null;
        bleeding = false;
    }
}