using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Zenject;

public class YarnPlayerControl : MonoBehaviour
{
    [Inject] PlayerUnit playerUnit;

    [YarnCommand("offPlayer")]
    public void offPlayer() {

        playerUnit.gameObject.SetActive(false);
    }
    [YarnCommand("onPlayer")]
    public void onPlayer() {

        playerUnit.gameObject.SetActive(true);
    }
    [YarnCommand("setPosPlayer")]
    public void setPosPlayer(GameObject target) {
        playerUnit.transform.position = target.transform.position;
    }
    [YarnCommand("setPosPlayerCut")]
    public void setPosPlayerCut(GameObject target) {
        target.transform.position = playerUnit.transform.position; 

    }
}
