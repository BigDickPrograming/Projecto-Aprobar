using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTranslate : MonoBehaviour {
    [SerializeField] string _ID;
    [SerializeField] LanguageManager _manager;
    [SerializeField] TextMeshProUGUI _myView;
    public bool needToLoad = false;
    void Awake(){
        //_manager = FindObjectOfType<LanguageManager>();
        _manager = LanguageManager.instance;
        if(_manager != null){
            _manager.onUpdate += ChangeLang;
            if(needToLoad){
                ChangeLang();
            }
        }
    }

    void ChangeLang(){
        //var value = int.Parse(_manager.GetTranslate(_ID));
        var value = _manager.GetTranslate(_ID);
        if(value != ""){
            _myView.text = value;
        }
    }

    private void OnDisable(){
        _manager.onUpdate -= ChangeLang;
    }
}