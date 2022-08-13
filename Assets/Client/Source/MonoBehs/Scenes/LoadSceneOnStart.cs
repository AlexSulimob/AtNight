using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnStart : MonoBehaviour
{
    public string loadSceneName;
    void Start() {
        SceneManager.LoadSceneAsync(loadSceneName, LoadSceneMode.Additive);
    }
}
