using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;

/// <summary>
/// Reload scene if player in trigger. Player must have "Player" tag
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class DeadTrigger : MonoBehaviour {
    [Inject]PlayerUnit playerUnit;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Vector2 newPos = new Vector2();
            newPos.x = PlayerPrefs.GetFloat("PlayerPosX");
            newPos.y = PlayerPrefs.GetFloat("PlayerPosY");

            playerUnit.transform.position =  newPos;
        }
               
    }
}
