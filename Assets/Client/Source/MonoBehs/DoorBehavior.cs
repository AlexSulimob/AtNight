using UnityEngine;
using Zenject;

public class DoorBehavior : MonoBehaviour
{
    [Inject]
    InputService inputService;

    public Animator animator;
    public doorState state; 
    bool inTrigger;

    void Update()
    {
        // Debug.Log(inputService.INTERACTION_INPUT_DOWN);
        if(inTrigger && inputService.INTERACTION_INPUT_DOWN)
        {
            // Debug.Log(inTrigger);
            switch (state)
            {
                case doorState.open: 
                    animator.SetTrigger("close");
                    state = doorState.close; 
                    break;
                case doorState.close:
                    animator.SetTrigger("open"); 
                    state = doorState.open; 
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            inTrigger = true;
        }    
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            inTrigger = false;
        }    
    }


    public enum doorState 
    {
        open,
        close
    }
}
