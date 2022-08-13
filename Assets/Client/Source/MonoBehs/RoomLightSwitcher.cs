using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomLightSwitcher : MonoBehaviour
{
    [Inject]
    InputService inputService;

    public Animator animator;
    public switcherState state; 
    bool inTrigger;

    void Update()
    {
        if(inTrigger && inputService.INTERACTION_INPUT_DOWN)
        {
            // Debug.Log(inTrigger);
            switch (state)
            {
                case switcherState.on: 
                    animator.SetTrigger("off");
                    state = switcherState.off; 
                    break;
                case switcherState.off:
                    animator.SetTrigger("on"); 
                    state = switcherState.on; 
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            inTrigger = true;
        }    
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            inTrigger = false;
        }    
    }

    public enum switcherState 
    {
        on,
        off
    }
}
