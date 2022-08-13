using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class LaserAnimatorController : MonoBehaviour
{
    [Inject]
    InputService inputService;

    [SerializeField]Light2D flashlight;

    [SerializeField]LineRenderer laserLine;
    bool flag;
    [SerializeField]float transitionSpeed = 1f;
    [SerializeField]float innerAngelTarget = 34f;
    [SerializeField]float outerAngelTarget = 64f;
    [SerializeField]Laser laserobjs;
    
    void Update()
    {
        //pause check
        if(Time.timeScale == 0)
            return;


        bool isFocused = inputService.FLASHLIGHT_INPUT_HOLD; 
        if (isFocused && !flag)
        {
            DOTween.To(() => flashlight.pointLightInnerAngle, x=> flashlight.pointLightInnerAngle = x, 0f, transitionSpeed); 
            DOTween.To(() => flashlight.pointLightOuterAngle, x=> flashlight.pointLightOuterAngle= x, 0f, transitionSpeed); 
            laserLine.material.DOFade(1f,transitionSpeed);
            flag = true;
            laserobjs.isFocused = true;
        }
        else if (flag && !isFocused)
        {
            DOTween.To(() => flashlight.pointLightInnerAngle, x=> flashlight.pointLightInnerAngle = x, innerAngelTarget, transitionSpeed); 
            DOTween.To(() => flashlight.pointLightOuterAngle, x=> flashlight.pointLightOuterAngle= x, outerAngelTarget, transitionSpeed); 
            laserLine.material.DOFade(0f,transitionSpeed);
            flag = false;
            laserobjs.isFocused = false;
        }
    }
}
