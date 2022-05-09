using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
 
   public float time;
    public void Start() {
        Destroy(gameObject,time); 
    }
    

}
 