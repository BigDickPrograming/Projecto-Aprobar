using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour {
    public void SwitchLanguage(){
        LanguageManager.instance.SwitchLanguage();
    }
}