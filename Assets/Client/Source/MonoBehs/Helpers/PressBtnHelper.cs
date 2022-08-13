using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressBtnHelper : MonoBehaviour
{
    public Image image;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Interactable"))
        {
            image.enabled = true;           
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Interactable"))
        {
            image.enabled = false;           
        }
    }
}
