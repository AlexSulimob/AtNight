using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;
public class ExposedValueChangeOnTrigger : MonoBehaviour
{
    public string exposedValue;
    public float inTriggerValue = 0;
    public float outTriggerValue = 1;
    public AudioMixerGroup mixerGroup;
    public float speed = .05f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            mixerGroup.audioMixer.SetFloat(exposedValue, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            // defaultSnap.TransitionTo(speed);        
            mixerGroup.audioMixer.SetFloat(exposedValue, 1);
        }
    }
}
