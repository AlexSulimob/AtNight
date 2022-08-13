using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// play certain audio on anim event 
/// </summary>
public class PlaySoundAnimatorEvent : MonoBehaviour
{
    public AudioSource auidioSource;
    public void PlayerAudio(AudioClip clip)
    {
        // auidioSource.clip = clip;
        auidioSource.PlayOneShot(clip);
    }
}
