using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {
   public static AudioSource PlayerAudioSource {
   get {
         return _playerAudioSource;
      }
   }
   
   static AudioSource _playerAudioSource;
   public static Transform PlayerTransform {
   get {
         return _playerTransform;
      }
   }
   static Transform _playerTransform;
   private void Update() {
      _playerTransform = transform;
   }
   void Awake(){
      _playerAudioSource = GetComponent<AudioSource>();
   }
   private void OnEnable(){ 
      EventManager.Subscribe(EVENT.GAIN_HP, Heal);
      EventManager.Subscribe(EVENT.PLAYER_DAMAGEABLE, SetPlayerDamageable);
   }
   public override void Damage(float dmg){
      base.Damage(dmg);
      Debug.Log("Damage: " + dmg + " - _life: " + _life);
      EventManager.TriggerEvent(EVENT.LOSE_HP, _life);
   }

   public override void Death(){
      EventManager.TriggerEvent(EVENT.SHOW_ADD);
   }

   private void OnDisable(){
      EventManager.Unsubscribe(EVENT.GAIN_HP, Heal);
      EventManager.Unsubscribe(EVENT.PLAYER_DAMAGEABLE, SetPlayerDamageable);
   }

   public void adRewardedRevive(float amount = 50f){
      EventManager.TriggerEvent(EVENT.SHOW_ADD, amount);
   }

   void SetPlayerDamageable(params object[] p){
      bool isDamageable = (bool) p[0];
      damageable = isDamageable;
   }
}