using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {
    public GameObject mainButtons;
    public GameObject mainInstructions;
    public GameObject backButton;
    public GameObject controlMenu;
    public GameObject lvlsButton;
    private void Awake(){
        if(LevelManager.instance.currentLvl != Lvl.one){
            lvlsButton.SetActive(true);
        }
        else{
            lvlsButton.SetActive(false);
        }
    }
    public void Instructions(){
        mainButtons.SetActive(false);
        mainInstructions.SetActive(true);
        backButton.SetActive(true);
    }
    public void Back(){
        mainButtons.SetActive(true);
        mainInstructions.SetActive(false);
        backButton.SetActive(false);
    }
    public void ControlMenu(){
        controlMenu.SetActive(true);
        mainButtons.SetActive(false);
    }
}