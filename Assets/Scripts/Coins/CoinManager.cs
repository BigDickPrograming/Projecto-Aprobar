using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
    #region DontDestroyOnLoad
    private static CoinManager _instance;
    public static CoinManager Instance {
        get{
            if(_instance == null){
                _instance = GameObject.FindObjectOfType<CoinManager>();
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    void Awake(){
        if(_instance == null){
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if(this != _instance)
                Destroy(this.gameObject);
        }
    }
    #endregion
    [SerializeField] int _coins = 0;
    public int coins {get{ return _coins;}}
    public void addCoins(int value){
        _coins += value;
        EventManager.TriggerEvent(EVENT.UPDATE_CANVAS_COINS, _coins);
    }
}