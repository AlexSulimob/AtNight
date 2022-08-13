using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// change audio snapshop on  triger 
/// </summary>
public class SnapshotTransitionOnTrigger : MonoBehaviour
{
    public AudioMixerSnapshot defaultSnap;
    public AudioMixerSnapshot inRoomSnap;

    public float speed = .05f;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            inRoomSnap.TransitionTo(speed);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            defaultSnap.TransitionTo(speed);        
        }
    }
}
