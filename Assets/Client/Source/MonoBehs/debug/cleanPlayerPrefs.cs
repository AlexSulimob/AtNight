using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanPlayerPrefs : MonoBehaviour {
    void Start() {
        StartCoroutine(Co_cleanPlayerPrefs());
    }
    private IEnumerator Co_cleanPlayerPrefs() {
         yield return new WaitForSeconds(1f);
         PlayerPrefs.DeleteAll();
         Debug.Log("delelted all PlayerPrefs");
        // yield break;
    }

}
