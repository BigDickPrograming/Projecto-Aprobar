using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
//using IUnityAdsListener;
public class AdsManager : MonoBehaviour{

 public void Awake() {
     Advertisement.Initialize("4813981",true);
     //Advertisement.Initialize("4813981",false);
 }
 public void InsertAdd(){
    if(!Advertisement.IsReady()) return;
    var options = new ShowOptions();
    //options.resultCallback += onAddResult();
    //Advertisement.AddListener();
    Advertisement.Show("Rewarded_Android",options);
}
 void onAddResult(ShowResult result){
   if (result == ShowResult.Finished){
    Debug.Log("te doy 3 pokepeso");
   }
}
}
