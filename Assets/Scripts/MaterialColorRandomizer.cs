using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialColorRandomizer : MonoBehaviour
{
    [Tooltip("The minimum hue value to use for randomization.")]
    public float minHue = 0.0f;

    [Tooltip("The maximum hue value to use for randomization.")]
    public float maxHue = 1.0f;

    [Tooltip("The minimum saturation value to use for randomization.")]
    public float minSaturation = 0.0f;

    [Tooltip("The maximum saturation value to use for randomization.")]
    public float maxSaturation = 1.0f;

    [Tooltip("The minimum value (brightness) to use for randomization.")]
    public float minValue = 0.0f;

    [Tooltip("The maximum value (brightness) to use for randomization.")]
    public float maxValue = 1.0f;
 
    [HideInInspector] public Renderer _renderer;
    [HideInInspector] public Color resultColor;

 
    void Awake()
    {
        _renderer = GetComponent<Renderer>();

        // Generate and apply the randomized color.
        resultColor = Random.ColorHSV(minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue);
        _renderer.material.color = resultColor;
    }
}