using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener {
  protected string gameID = "4815076";
  public bool testMode = true;
  public void Awake() {
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
      Debug.Log("te doy 3 pokepeso");
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
}