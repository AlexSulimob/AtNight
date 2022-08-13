using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService {

    public bool isGameplayInputsOn = true;
    public bool isDialogueInputsOn = true;

    public float X_INPUT { get => isGameplayInputsOn ? Input.GetAxisRaw("Horizontal") : 0f; }
    public float Y_INPUT { get => isGameplayInputsOn ? Input.GetAxisRaw("Vertical") : 0f;}

    public bool JUMP_INPUT_DOWN { get => isGameplayInputsOn ? Input.GetButtonDown("Jump") : false;}
    public bool JUMP_INPUT_HOLD { get => isGameplayInputsOn ? Input.GetButton("Jump") : false;}
    public bool JUMP_INPUT_REALEASE { get => isGameplayInputsOn ? Input.GetButtonUp("Jump") : false;}

    public bool INTERACTION_INPUT_DOWN { get => isGameplayInputsOn ? Input.GetKeyDown(KeyCode.E) : false;}
    public bool INTERACTION_INPUT_HOLD { get => isGameplayInputsOn ? Input.GetKey(KeyCode.E) : false;}
    public bool INTERACTION_INPUT_REALEASE { get => isGameplayInputsOn ? Input.GetKeyUp(KeyCode.E) : false;}

    public bool FLASHLIGHT_INPUT_DOWN { get => isGameplayInputsOn ? Input.GetKeyDown(KeyCode.F) : false;}
    public bool FLASHLIGHT_INPUT_HOLD { get => isGameplayInputsOn ? Input.GetKey(KeyCode.F) : false;}
    public bool FLASHLIGHT_INPUT_REALEASE { get => isGameplayInputsOn ? Input.GetKeyUp(KeyCode.F) : false;}

    public bool PAUSE_INPUT_DOWN { get => isGameplayInputsOn ? Input.GetKeyDown(KeyCode.Escape) : false;}
    public bool PAUSE_INPUT_HOLD { get => isGameplayInputsOn ? Input.GetKey(KeyCode.Escape) :false;}
    public bool PAUSE_INPUT_REALEASE { get => isGameplayInputsOn ? Input.GetKeyUp(KeyCode.Escape) : false;}

    public Vector2 MOUSE_POS { get => isGameplayInputsOn ? Input.mousePosition : new Vector2(Screen.width/2, Screen.height/2); }

    public bool DIALOGUIE_NEXT_DOWN { get => isDialogueInputsOn ? Input.GetKeyDown(KeyCode.E) : false;}
    public bool DIALOGUIE_NEXT_HOLD { get => isDialogueInputsOn ? Input.GetKey(KeyCode.E) : false;}
    public bool DIALOGUIE_NEXT_REALEASE { get => isDialogueInputsOn ? Input.GetKeyUp(KeyCode.E) : false;}
    
}
