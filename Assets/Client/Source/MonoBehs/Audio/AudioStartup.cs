using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioStartup : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixerGroup mixerGroup;
    void Awake()
    {
        mixerGroup.audioMixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("masterVolume", 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
