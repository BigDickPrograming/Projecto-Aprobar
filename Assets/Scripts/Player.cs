using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{    
      public static Transform PlayerTransform {
        get {
           Debug.Log("devuelvo player");
            return _playerTransform;
         }
      }
     static Transform _playerTransform;
     void Update(){
        //_playerTransform = transform;
      }
     void Awake(){
        _playerTransform = transform;
      }
}
