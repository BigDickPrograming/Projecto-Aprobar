using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageLoader : MonoBehaviour {
    [SerializeField] SaveManager saveManager;
    void Start(){
        saveManager.LoadJSON();
    }
}
