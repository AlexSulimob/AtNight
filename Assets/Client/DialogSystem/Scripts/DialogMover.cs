using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;
using Yarn.Unity;

public class DialogMover : MonoBehaviour
{
    // [Inject] DialogueService service;
    public DialogueRunner runner;
    public CustomLineView lineView;
    NPC[] NPCs;
    public Dictionary<string, Transform> npcsDic = new Dictionary<string, Transform>();
    public Canvas MovableBubble;
    
    bool bubbleUpdate;

    void Start()
    {
        UpdatePos();
    }
    private void Update() {
        if (runner.IsDialogueRunning && bubbleUpdate)
        {
            UpdatePos();
            bubbleUpdate = false;
        }
        if (!runner.IsDialogueRunning) {
            MovableBubble.transform.position = new Vector2(0f, 9999f);
            bubbleUpdate = true;
        }

        if (runner.IsDialogueRunning && lineView.CurrentLine != null) {
            MovableBubble.transform.position = npcsDic[lineView.CurrentLine.CharacterName].position;
        }
    }
    void UpdatePos()
    {
        npcsDic.Clear();
        NPCs = FindObjectsOfType<NPC>();
        foreach (var item in NPCs) {
            npcsDic.Add(item.name, item.transform);
        }
    }

}
