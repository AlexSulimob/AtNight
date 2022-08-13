using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using Zenject;

public class MenuBtnBehaviour : MonoBehaviour {
    [Inject] PlayerUnit player_service;
    public GameObject LoadingScreen;
    // TODO: need to do warning before setting saves to starting position
    public void OnStartBtnClick() {
        PlayerPrefs.SetFloat("PlayerPosX", 0f);
        PlayerPrefs.SetFloat("PlayerPosY", -2.5f);
        // SceneManager.LoadSceneAsync("l1p1");

        LoadingScreen.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());   
    }

    public void OnContinueBtnClick() {

        LoadingScreen.SetActive(true);
        StartCoroutine(ContinueScene());   
    }
    IEnumerator ContinueScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation level = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("level"), LoadSceneMode.Additive);

        SceneManager.LoadSceneAsync("RainAndThunder", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("GameplayScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);

        while ( !level.isDone)
        {
            yield return null;
        }
        LoadingScreen.SetActive(false);
        player_service.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"),PlayerPrefs.GetFloat("PlayerPosY"),0f);
        player_service.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation intro = SceneManager.LoadSceneAsync("IntroCutscene", LoadSceneMode.Additive);
        AsyncOperation level = SceneManager.LoadSceneAsync("l1p1", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("RainAndThunder", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("GameplayScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);

        while (!intro.isDone && !level.isDone)
        {
            yield return null;
        }

        LoadingScreen.SetActive(false);
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
