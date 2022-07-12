using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour {
    [SerializeField] Slider _sliderHp;
    [SerializeField] TextMeshProUGUI _coins;
    private void OnEnable(){
        EventManager.Subscribe(EVENT.GAIN_HP, GainHP);
        EventManager.Subscribe(EVENT.LOSE_HP, LoseHP);
        EventManager.Subscribe(EVENT.UPDATE_CANVAS_COINS, UpdateCoins);
        _coins.text = ""+CoinManager.Instance.coins;
    }

    private void OnDisable(){
        EventManager.Unsubscribe(EVENT.GAIN_HP, GainHP);
        EventManager.Unsubscribe(EVENT.LOSE_HP, LoseHP);
        EventManager.Unsubscribe(EVENT.UPDATE_CANVAS_COINS, UpdateCoins);
    }

    void GainHP(params object[] p){
        _sliderHp.value += (float)p[0];
    }
    void LoseHP(params object[] p){
        _sliderHp.value = (float)p[0];
    }
    void UpdateCoins(params object[] p){
        _coins.text = ""+(int)p[0];
    }
}
