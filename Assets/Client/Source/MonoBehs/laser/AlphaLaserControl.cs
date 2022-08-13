using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaLaserControl : MonoBehaviour
{
    [Range(0, 255)]
    public float alphaValue;
    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        var currentColor = lineRenderer.material.color;
        lineRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alphaValue);
    }
}
