using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {   
[SerializeField] 
public GameObject Player;
 public static Transform PlayerTransform{
   get {
         return _transform;
      }
   }
   private static Transform _transform;

 void Update(){
    _transform = Player.transform;
    

}

}
