using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    [SerializeField] Slider _sliderHp;
    private void OnEnable(){
        EventManager.Subscribe(EVENT.GAIN_HP, GainHP);
        EventManager.Subscribe(EVENT.LOSE_HP, LoseHP);
    }

    private void OnDisable(){
        EventManager.Unsubscribe(EVENT.GAIN_HP, GainHP);
        EventManager.Unsubscribe(EVENT.LOSE_HP, LoseHP);
    }

    void GainHP(params object[] p){
        _sliderHp.value += (float)p[0];
    }
    void LoseHP(params object[] p){
        _sliderHp.value = (float)p[0];
    }
}
