using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReciver : MonoBehaviour
{
    public GameObject[] lightsOn;
    bool inTrigger;
    public Animator animator;
    public bool isGettingRay;

    // private void OnTriggerEnter2D(Collider2D other) {
    // }

    // private void OnTriggerExit2D(Collider2D other) {
    // }
    void Update() {

        if (isGettingRay) {
            animator.SetTrigger("turningOn");
        }
        else {
            animator.SetTrigger("off");
        }
        
    }

    public void OnLight()
    {
        animator.SetTrigger("on");
        foreach (var item in lightsOn)
        {
            item.SetActive(true);
        }
    }
}
