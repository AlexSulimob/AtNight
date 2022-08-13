using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Yarn.Unity;
public class MovementYarnCommand : MonoBehaviour
{
    [YarnCommand("walk")]
    public void Walk(GameObject target, float speed=3f)
    {
        transform.DOMove(target.transform.position, speed);
    }
}
