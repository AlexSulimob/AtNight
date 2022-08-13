using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasicYarnCommands : MonoBehaviour
{
    [HideInInspector] public static BasicYarnCommands instance;
    public Image blackPanel; 
    void Awake()
    {
        instance = this;
    }

    [YarnCommand("fade_in_camera")]
    public static void FadeCamera(float duration = 1) {
        DOTween.To(() => BasicYarnCommands.instance.blackPanel.color, x=> BasicYarnCommands.instance.blackPanel.color = x,new Color(0,0,0,1), duration); 
    }

    [YarnCommand("fade_out_camera")]
    public static void FadeOutCamera(float duration = 1) {
        DOTween.To(() => BasicYarnCommands.instance.blackPanel.color, x=> BasicYarnCommands.instance.blackPanel.color = x,new Color(0,0,0,0), duration); 
    }
    [YarnCommand("load_scene")]
    public static void load_scene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
    [YarnCommand("unload_scene")]
    public static void unload_scene(string sceneName) {
        SceneManager.UnloadSceneAsync(sceneName);
    }
    [YarnCommand("off_go")]
    public static void off_go(GameObject go) {
        go.SetActive(false);
    }
    [YarnCommand("on_go")]
    public static void on_go(GameObject go) {
        go.SetActive(true);
    }
}
