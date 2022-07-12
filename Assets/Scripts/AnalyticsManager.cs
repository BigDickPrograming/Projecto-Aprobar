using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour {
    #region DontDestroyOnLoad
    private static AnalyticsManager _instance;
    public static AnalyticsManager instance {
        get{
            if(_instance == null){
                _instance = GameObject.FindObjectOfType<AnalyticsManager>();
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
    int time = 0;
    bool counting = false;
    public void SendLevelStartedEvent(int lvl){
        Debug.Log("LevelStarted: "+ lvl);
        Analytics.SendEvent("LevelStarted", lvl);
        counting = true;
        StartCoroutine(Timer());
    }

    IEnumerator Timer(){
        while(counting){
            yield return new WaitForSeconds(1f);
            time++;
        }
    }

    public void SendLevelFinishedEvent(int lvl){
        Analytics.SendEvent("LevelFinished", lvl, time);
        Debug.Log("LevelFinished: "+ lvl + " - time: " + time);
        counting = false;
        time = 0;
    }

    public void SendDeathEvent(int lvl){
        Analytics.SendEvent("DiedOnLevel", lvl);
        Debug.Log("DiedOnLevel: "+ lvl);
        counting = false;
        time = 0;
    }
}