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
    [SerializeField] Language _selectedLanguage;
    [SerializeField] string _externalURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vRU7_Z0zkdP_hjIx4vMT7mlc6o9wu24tavV-o6alovSh-mlfYhnAvyIwPaYupHm3z4IV-2PR9Mb06I-/pub?gid=0&single=true&output=csv";
    [SerializeField] Dictionary<Language, Dictionary<string, string>> _languageManager;
    public event Action onUpdate = delegate { };
    void Start(){
        StartCoroutine(DownloadCSV(_externalURL));
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.U)){
            EventManager.TriggerEvent(EVENT.WINGAME);
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