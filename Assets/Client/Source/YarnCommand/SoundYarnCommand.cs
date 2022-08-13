using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using DG.Tweening;

public class SoundYarnCommand : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    [YarnCommand("play_sound_on")]
    public void Play_sound_on(float toVolume = 1, float duration = 1, bool dontDestroyOnLoad = false) {
        audioSource.volume = 0;
        audioSource.Play();
        DOTween.To(() => audioSource.volume, x=> audioSource.volume = x, toVolume, duration); 
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this);
        }
    }
    [YarnCommand("play_sound_off")]
    public void Play_sound_off(float duration = 1) {
        audioSource.Play();
        DOTween.To(() => audioSource.volume, x=> audioSource.volume = x, 0f, duration); 
    }
}
