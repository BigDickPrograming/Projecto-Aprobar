using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
    public static CoinManager Instance {
        get {
            return _instance;
        }
    }
    static CoinManager _instance;
    int _coins = 0;
    void Start(){
        _instance = this;
    }
    
    public void addCoins(int value){
        _coins += value;
    }
}
