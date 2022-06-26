using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TextoParpadeante : MonoBehaviour {
    [SerializeField] TextMeshProUGUI _text = null;
    [SerializeField] MySceneManager sceneManager;

    void Start(){
        if(_text == null)_text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ParpadeoTexto());
    }

    void Update(){
        if (Input.anyKey){
            sceneManager.loadScene("MainMenu");
        }
    }

    IEnumerator ParpadeoTexto(){
        while(true){
            for(float i = 0f; i < 20f; i++){
                _text.color = new Color(1f, 1f, 1f, i/20f);
                yield return new WaitForSeconds(.05f);
            }
            yield return new WaitForSeconds(.1f);
            for(float i = 15f; i >= 0f; i--){
                _text.color = new Color(1f, 1f, 1f, i/15f);
                yield return new WaitForSeconds(.05f);
            }
            yield return new WaitForSeconds(.05f);
        }
    } 
}