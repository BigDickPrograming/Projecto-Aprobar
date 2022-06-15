using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class SaveManager : MonoBehaviour {
    [SerializeField] LanguageManager saveData;
    string saveDataPath;
    void Start(){
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/");
        Debug.Log(documents);
        System.IO.Directory.CreateDirectory(documents + "/TinyDungeon/");
        saveDataPath = documents + "/TinyDungeon" + "/PlayerSave.json";
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.S))
            SaveJSON();
        else if (Input.GetKeyDown(KeyCode.L))
            LoadJSON();
    }

    public void SaveJSON(){
        string json = JsonUtility.ToJson(saveData, true);
        Debug.Log(saveDataPath);
        File.WriteAllText(saveDataPath, json);
    }

    public void LoadJSON(){
        if (!File.Exists(saveDataPath)) return;
        string json = File.ReadAllText(saveDataPath);
        JsonUtility.FromJsonOverwrite(json, saveData);
    }
    private void OnDisable(){
        Debug.Log("Guardo el json");
        SaveJSON();
    }
}
