using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveScreen : MonoBehaviour {
    [SerializeField] GameObject modal;

    private void OnEnable(){ 
        EventManager.Subscribe(EVENT.SHOW_ADD, ShowAddModal);
    }
    private void OnDisable(){
        EventManager.Unsubscribe(EVENT.SHOW_ADD, ShowAddModal);
    }
    void ShowAddModal(params object[] p){
        ShowModal();
        EventManager.TriggerEvent(EVENT.PLAYER_DAMAGEABLE, false);
    }
    void ShowModal(bool show = true){
        modal.SetActive(show);
    }
    public void CancelOption(){
        ShowModal(false);
        EventManager.TriggerEvent(EVENT.LOSEGAME);
        EventManager.TriggerEvent(EVENT.PLAYER_DAMAGEABLE, true);
    }
    public void AcceptOption(){
        Time.timeScale = 0f;
        ShowModal(false);
        AdsManager.instance.InsertAdd();
    }
}