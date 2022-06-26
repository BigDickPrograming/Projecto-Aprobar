using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public enum Language {
    eng,
    spa,
}

[Serializable]
public class LanguageManager : MonoBehaviour {
    #region DontDestroyOnLoad
    private static LanguageManager _instance;
    public static LanguageManager instance {
        get{
            if(_instance == null){
                _instance = GameObject.FindObjectOfType<LanguageManager>();
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
    [SerializeField] Language _selectedLanguage;
    [SerializeField] string _externalURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vRU7_Z0zkdP_hjIx4vMT7mlc6o9wu24tavV-o6alovSh-mlfYhnAvyIwPaYupHm3z4IV-2PR9Mb06I-/pub?gid=0&single=true&output=csv";
    [SerializeField] Dictionary<Language, Dictionary<string, string>> _languageManager;
    public event Action onUpdate = delegate { };
    void Start(){
        StartCoroutine(DownloadCSV(_externalURL));
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.O)){
            EventManager.TriggerEvent(EVENT.WINGAME, Lvl.one);
        }
        if (Input.GetKeyDown(KeyCode.T)){
            EventManager.TriggerEvent(EVENT.WINGAME, Lvl.two);
        }
    }

    public void updateLanguage(){
        onUpdate();
    }

    public string GetTranslate(string id){
        if(id == null) return "";
        if (!_languageManager[_selectedLanguage].ContainsKey(id)){
            return "";
        }
        else{
            return _languageManager[_selectedLanguage][id];
        }
    }

    IEnumerator DownloadCSV(string url){
        var www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        _languageManager = LanguageU.LoadCodexFromString("www", www.downloadHandler.text);

        onUpdate();
    }

    public void SwitchLanguage(){
        if (_selectedLanguage == Language.eng) _selectedLanguage = Language.spa;
        else _selectedLanguage = Language.eng;
                
        onUpdate();
    }
}