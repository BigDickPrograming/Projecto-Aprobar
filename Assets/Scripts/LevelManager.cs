using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Lvl {
    one,
    two,
    won
}

[Serializable]
public class LevelManager : MonoBehaviour {
    #region DontDestroyOnLoad
    private static LevelManager _instance;
    public static LevelManager instance {
        get{
            if(_instance == null){
                _instance = GameObject.FindObjectOfType<LevelManager>();
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

    [SerializeField] public Lvl currentLvl = Lvl.one;
    private void Start(){
        LevelSaveManager.instance.LoadJSON();
    }
    private void OnEnable(){
        EventManager.Subscribe(EVENT.LOSEGAME, OnLose);
        EventManager.Subscribe(EVENT.WINGAME, OnWin);
    }
    private void OnDisable(){
        EventManager.Unsubscribe(EVENT.WINGAME, OnWin);
        EventManager.Unsubscribe(EVENT.LOSEGAME, OnLose);
    }
    void OnWin(params object[] p){
        switch((Lvl)p[0]){
            case Lvl.one:
                currentLvl = Lvl.two;
                AnalyticsManager.instance.SendLevelFinishedEvent(1);
                AnalyticsManager.instance.SendLevelStartedEvent(2);
                break;
            case Lvl.two:
            default:
                AnalyticsManager.instance.SendLevelFinishedEvent(2);
                currentLvl = Lvl.won;
                break;
        }
        LevelSaveManager.instance.SaveJSON();
    }
    public void ResetLevels(){
        currentLvl = Lvl.one;
        LevelSaveManager.instance.SaveJSON();
    }
    void OnLose(params object[] p){
        int lvl = 0;
        switch(currentLvl){
            case Lvl.one:
                lvl = 1;
                break;
            case Lvl.two:
                lvl = 2;
                break;

        }
        AnalyticsManager.instance.SendDeathEvent(lvl);
    }
}
