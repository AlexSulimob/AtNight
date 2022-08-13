using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ParallaxBehaviour : MonoBehaviour {
    [Inject] PlayerUnit playerUnit;
    Transform followingTarget;
    [SerializeField, Range(0f, 1f)] float parallaxStrength = 0.1f;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPosition;
    void Start() {
        followingTarget = playerUnit.transform;
        if (!followingTarget) {
            followingTarget = Camera.main.transform;
        }
        targetPreviousPosition = followingTarget.position;
        
    }
    void Update() {
        var delta = followingTarget.position - targetPreviousPosition;
        if (disableVerticalParallax) {
            delta.y = 0;
        }
        targetPreviousPosition = followingTarget.position;
        transform.position += delta * parallaxStrength;
        
    }

}
