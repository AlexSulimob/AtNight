using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AnimationYarnCommand : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    [YarnCommand("set_anim")]
    public void Walk(string animName)
    {
        animator.SetTrigger(animName);
    }

    [YarnCommand("flip")]
    public void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}
