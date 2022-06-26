using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Lvl {
    one,
    two
}

public class MySceneManager : MonoBehaviour {
    public static MySceneManager menuController;
    private void Start(){
        menuController = this;
    }
    public void loadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    public void reloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quitGame(){
        Debug.Log("Quitting...");
        Application.Quit();
    }
    private void OnEnable(){
        EventManager.Subscribe(EVENT.LOSEGAME, OnLose);
        EventManager.Subscribe(EVENT.WINGAME, OnWin);
    }
    private void OnDisable(){
        EventManager.Unsubscribe(EVENT.LOSEGAME, OnLose);
        EventManager.Unsubscribe(EVENT.WINGAME, OnWin);
    }
    void OnLose(params object[] p){
        loadScene("LoseScene");
    }
    void OnWin(params object[] p){
        switch((Lvl)p[0]){
            case Lvl.one:
                loadScene("Nivel2");
                break;
            case Lvl.two:
                loadScene("WinScene");
                break;
            default:
                loadScene("WinScene");
                break;
        }
    }
}