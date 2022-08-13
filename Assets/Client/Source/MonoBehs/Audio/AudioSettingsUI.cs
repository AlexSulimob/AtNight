using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    public AudioMixerGroup master_mixer;
    private void Awake() {
        GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("masterVolume");
    }
    public void ChangeVolume(float volume)
    {
        master_mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80f,0f, volume));
        PlayerPrefs.SetFloat("masterVolume", volume);
    }
}
