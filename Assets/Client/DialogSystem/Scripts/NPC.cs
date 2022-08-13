using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Zenject;

public class NPC : MonoBehaviour
{
    [Inject] InputService inputService;
    [Inject] DialogueService dialogueService;
    public bool startOnAwake;
    public string talkToNode;

    bool PlayerInTrigger;
    public bool startOnTrigger;
    void Awake()
    {
        dialogueService.AddNpcForDialogueMover(transform.name, transform);
        if(startOnAwake)
        {
            dialogueService.runner.StartDialogue(talkToNode);
        }
    }
    void Update() {
        if (PlayerInTrigger 
                && inputService.INTERACTION_INPUT_DOWN 
                && !dialogueService.runner.IsDialogueRunning){
            dialogueService.runner.StartDialogue(talkToNode);
            // runnerService.dialogueStartInputsFix = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
       if (other.CompareTag("Player")) {
            PlayerInTrigger = true;
            if (startOnTrigger)
            {
                dialogueService.runner.StartDialogue(talkToNode);
            }
       }
        
    }
    void OnTriggerExit2D(Collider2D other) {
        
       if (other.CompareTag("Player")) {
            PlayerInTrigger = false;
       }
    }

}
