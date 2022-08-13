using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Playe behaviour on one way plafrom when pressed down button. 
/// </summary>
public class PlayerOneWayPlatformBehaviour : MonoBehaviour {

    [Inject]
    InputService inputService;

    private Dictionary<GameObject, GameObject> currentOnwWayPlaftorm = new Dictionary<GameObject, GameObject>();  
    [SerializeField]private BoxCollider2D playerCollider;

    List<BoxCollider2D> cacheColliders = new List<BoxCollider2D>(); 
    bool coroutineIsStarted = false;
    void Update() {
        if (inputService.Y_INPUT == -1f) {
            if (currentOnwWayPlaftorm != null && !coroutineIsStarted) {
                StartCoroutine(Co_DisableCollision()); 
                coroutineIsStarted = true;
            }
        }
    }
    // TODO: optimize code. perfectly i need just check ground platform and turn
    // physics only on this withouth f 3 loop foreasch
    private IEnumerator Co_DisableCollision() {
        foreach (var item in currentOnwWayPlaftorm) {
            cacheColliders.Add(item.Value.GetComponent<BoxCollider2D>());
        }
        foreach (var item in cacheColliders) {
            Physics2D.IgnoreCollision(playerCollider, item);
        }
        yield return new WaitForSeconds(0.25f);
        foreach (var item in cacheColliders) {
            Physics2D.IgnoreCollision(playerCollider, item, false);
        }
        cacheColliders.Clear();
        coroutineIsStarted = false;
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("OneWayPlatform")) {
            currentOnwWayPlaftorm.Add(other.gameObject, other.gameObject);
            // currentOnwWayPlaftorm = other.gameObject; 
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("OneWayPlatform")) {
            currentOnwWayPlaftorm.Remove(other.gameObject);
            // currentOnwWayPlaftorm = null; 
        }
    }

}
