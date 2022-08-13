using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PauseUiBehaviour : MonoBehaviour {
    
    [Inject]
    InputService inputService;
    bool isPaused;
    public GameObject PauseUi;
    public GameObject LoadingScreen;
    public GameObject Settings;

    void Update() {
        if (inputService.PAUSE_INPUT_DOWN){
            if (!isPaused) {
                Pause();
            } else {
                UnPause();
            }
        }
        
    }
    void Pause(){
        Time.timeScale = 0f;
        isPaused = true;
        PauseUi.SetActive(true);
        // Coursour
        Cursor.visible = true;
    }

    void UnPause(){
        Time.timeScale = 1f;
        isPaused = false;
        PauseUi.SetActive(false);
        Settings.SetActive(false);
        Cursor.visible = false;
    }
    public void ContinueBtnClick(){
        UnPause();
    }
    public void ExitToMainMenuBtnClick(){
        /*
        UnPause();
        SceneManager.LoadSceneAsync("MainMenu");
        LoadingScreen.SetActive(true);
        */
    }

}
