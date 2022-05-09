using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour {
    public int value = 1;
    public AudioClip clip;
    [SerializeField]
     AudioSource audio;
    
     /*void Update(){
        if (value < 5){
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
        CoinSound();
        CoinManager.Instance.addCoins(this.value);
        CoinFactory.Instance.ReturnCoin(this);
    }

    void setCoinValue(){
        int random = Random.Range(1, 11);
        if(random <= 5){
            value = 1;
        }
        else if(random <= 8){
            value = 2;
        }
        else{
            value = 5;
        }
    }
     public void CoinSound(){    
        GameObject gameobject = new GameObject("audio");
        var audiogameobject = gameobject.AddComponent<AudioSource>();
        audiogameobject = audio;
        gameobject.AddComponent<Destroyer>();
        Instantiate(gameobject, transform.position,Quaternion.identity);
    }
}
