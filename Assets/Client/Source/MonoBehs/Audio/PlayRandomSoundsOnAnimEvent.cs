using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player random audio from array on anim event 
/// </summary>
public class PlayRandomSoundsOnAnimEvent: MonoBehaviour
{
    public AudioClip[] audioes;
    public AudioSource source;
    public void Play()
    {
        // Debug.Log("Play");
        source.clip = audioes[Random.Range(0, audioes.Length-1)];
        source.Play();


    }
}
