using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour { 
    public Entity entidad;
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            entidad.Death();
        }
    }

    
}
