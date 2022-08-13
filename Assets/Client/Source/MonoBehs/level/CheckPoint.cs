using UnityEngine;

/// <summary>
/// Player check point. If Player in trigger we save in PlayerPrefs
/// PlayerPosition 
/// Player must have "Player" tag
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class CheckPoint : MonoBehaviour {
    public string level;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
            PlayerPrefs.SetString("level", level);
            PlayerPrefs.Save();
        }
        
    }
}
