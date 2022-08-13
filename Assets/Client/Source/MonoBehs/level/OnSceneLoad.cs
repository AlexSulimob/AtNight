using UnityEngine;

public class OnSceneLoad : MonoBehaviour {
    public bool turnOff;
    public GameObject player;
    void Awake() {
        if (turnOff)
            return;

        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY")) {
            player.transform.position = new Vector2( PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY") );
        }        
    }

}
