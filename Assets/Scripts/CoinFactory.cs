using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFactory : MonoBehaviour {
    public static CoinFactory Instance {
        get {
            return _instance;
        }
    }
    static CoinFactory _instance;
    public Coin coinPrefab;
    public int coinStock = 5;
    public ObjectPool<Coin> pool;

    void Start(){
        _instance = this;
        pool = new ObjectPool<Coin>(CoinCreator, Coin.TurnOn, Coin.TurnOff, coinStock);
    }

    public Coin CoinCreator(){
        return Instantiate(coinPrefab);
    }

    public void ReturnCoin(Coin c){
        pool.ReturnObject(c);
    }
}