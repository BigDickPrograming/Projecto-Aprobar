using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public int _value = 1;
    /*void Update(){
        if (_value < 5){
        }
    }*/

    private void Reset(){
        setCoinValue();
    }

    public static void TurnOn(Coin c){
        c.Reset();
        c.gameObject.SetActive(true);
    }

    public static void TurnOff(Coin c){
        c.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("Llego " + this.name + " value: "+ _value);
        CoinManager.Instance.addCoins(this._value);
        CoinFactory.Instance.ReturnCoin(this);
    }

    void setCoinValue(){
        int random = Random.Range(1, 11);
        if(random <= 5){
            _value = 1;
        }
        else if(random <= 8){
            _value = 2;
        }
        else{
            _value = 5;
        }
    }
}
