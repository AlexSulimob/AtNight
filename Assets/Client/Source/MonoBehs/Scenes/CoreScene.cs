using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
public class CoreScene : MonoBehaviour
{
    [Inject]PlayerUnit playerUnit;
    private void Awake() {
        playerUnit.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync("Camera", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive); 
        // SceneManager.LoadSceneAsync("RainAndThunder", LoadSceneMode.Additive); 
    }
}