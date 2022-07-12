using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener {
  #region DontDestroyOnLoad
    private static AdsManager _instance;
    public static AdsManager instance {
        get{
            if(_instance == null){
                _instance = GameObject.FindObjectOfType<AdsManager>();
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
  #endregion

  protected string gameID = "4815076";
  public bool testMode = false;
  public void Awake() {
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
     Advertisement.Initialize(gameID, testMode);
     Advertisement.AddListener(this);
     Debug.Log("iniciado");
     //Advertisement.Initialize("4813981",false);
  } 
  public void InsertAdd(){
    if(!Advertisement.IsReady()) return;
    var options = new ShowOptions();
    options.resultCallback += onAddResult;
   // Advertisement.AddListener();
    Advertisement.Show("Rewarded_Android", options);
  }
  void onAddResult(ShowResult result){
    if (result == ShowResult.Finished){
      EventManager.TriggerEvent(EVENT.GAIN_HP, 50f);
      Time.timeScale = 1f;
      StartCoroutine(WaitForRevive());
    }
  }
  public void OnUnityAdsReady(string placementid){
    Debug.Log("Ads listos para reproducir");
  }
  public void OnUnityAdsDidError(string message){
    Debug.Log("Error" + message);
  }
  public void OnUnityAdsDidStart(string placementid){
    Debug.Log("comenzo el add");
  }
  public void OnUnityAdsDidFinish(string placementid,ShowResult showresult){
    if(placementid == "rewardedvideo" && showresult == ShowResult.Finished)
      Debug.Log("recompenso al jugador");
  }

  IEnumerator WaitForRevive(){
    yield return new WaitForSeconds(2f);
    EventManager.TriggerEvent(EVENT.PLAYER_DAMAGEABLE, true);
  }
}