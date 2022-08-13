using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Zenject;

public class DialogueInputs : MonoBehaviour
{
    [Inject] InputService inputService;
    public CustomLineView lineView;
    public DialogueRunner runner;
    void Update() {
        if (inputService == null)
        {
            return;
        }
        // Debug.Log("i am here");
        if (inputService.DIALOGUIE_NEXT_DOWN) {
            lineView.OnContinueClicked();
        }

        if(runner.IsDialogueRunning) {
            BlockGameplayInputs();
        }
        else {
            UnBlockGameplayInputs();
        }
    }
    public void BlockGameplayInputs(){
        inputService.isGameplayInputsOn = false;
    }
    public void UnBlockGameplayInputs(){
        inputService.isGameplayInputsOn = true;
    }
}
