using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {
   public static Transform PlayerTransform {
   get {
      Debug.Log("devuelvo player");
         return _playerTransform;
      }
   }
   static Transform _playerTransform;
   void Awake(){
      _playerTransform = transform;
   }
   private void OnEnable(){ 
      EventManager.Subscribe(EVENT.GAIN_HP, Heal);
   }
   public override void Damage(float dmg){
      base.Damage(dmg);
      Debug.Log("Damage: " + dmg + " - _life: " + _life);
      EventManager.TriggerEvent(EVENT.LOSE_HP, _life);
   }

   public override void Death(){
      EventManager.TriggerEvent(EVENT.LOSEGAME);
   }

   private void OnDisable(){
      EventManager.Unsubscribe(EVENT.GAIN_HP, Heal);
   }
}