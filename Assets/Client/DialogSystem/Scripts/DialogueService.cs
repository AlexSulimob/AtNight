using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueService : MonoBehaviour {
    public DialogueRunner runner;
    public CustomLineView lineView;
    public DialogMover dialogMover;
    public TextLineProvider lineProvider;
    [HideInInspector] public bool dialogueStartInputsFix;
    public void AddNpcForDialogueMover(string name, Transform transform)
    {
        dialogMover.npcsDic.Add(name, transform);
    }
}
