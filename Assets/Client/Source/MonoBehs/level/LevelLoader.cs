using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelLoader : MonoBehaviour {
    
    [Inject]PlayerUnit playerUnit;
    bool isLoaded = false;
    bool shouldLoad = false;
    // public string nameScene;

    void Start() {

        if (SceneManager.sceneCount > 0) {
            for (int i = 0; i < SceneManager.sceneCount; ++i) {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == gameObject.name) {
                    isLoaded = true;
                    Debug.Log(gameObject.name + "  " + isLoaded);
                }
            }
        }
        
    }
    void Update() {
        if (!playerUnit.gameObject.active) 
        {return;} 

        Check();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            shouldLoad = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            shouldLoad = false;
        }
    }
    void Check(){
        if (shouldLoad) {
            LoadScene();
        }
        else {
            UnLoadScene();
        }
    }

    void LoadScene(){
        if (!isLoaded) {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }
    void UnLoadScene(){
        if (isLoaded) {
            Debug.Log("was here");
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }
}
