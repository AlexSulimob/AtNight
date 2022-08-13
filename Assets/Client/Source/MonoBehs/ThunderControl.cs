using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderControl : MonoBehaviour
{
    public Animator animator;
    public float randomRange1 = 5f;
    public float randomRange2 = 10f;

    public AudioClip[] audioes;
    public AudioSource source;

    void Start()
    {
        StartCoroutine("Thunder");     
    }

    IEnumerator Thunder()
    {
        while (true)
        {
            animator.SetTrigger("Thunder");
            yield return new WaitForSeconds(Random.Range(randomRange1, randomRange2));
        }
    }
    public void PlayerThunderSound()
    {
        source.clip = audioes[Random.Range(0, audioes.Length)];
        source.Play();
    }
}
