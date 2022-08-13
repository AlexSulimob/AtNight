using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cinemachine;

public class PlayerCMCamera : MonoBehaviour
{
    [Inject] PlayerUnit playerUnit;
    
    public CinemachineVirtualCamera vcCamera;
    // Start is called before the first frame update
    void Start()
    {
        vcCamera.Follow = playerUnit.transform.Find("targetOfCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerUnit.isActiveAndEnabled)
        {
            vcCamera.gameObject.SetActive(true);
        }
    }
}
