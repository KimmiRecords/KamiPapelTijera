using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialColorRandomizer : MonoBehaviour
{
    [Tooltip("Si true, usa el color del material como base. Si no, usa el color que asignes.")]
    [SerializeField] bool useMaterialColor;
    [SerializeField] Color baseColor;
    [SerializeField] float hueVariation, saturationVariation, valueVariation;
    Renderer _renderer;

    
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        //resultColor = Random.ColorHSV(minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue);
        //_renderer.material.color = resultColor;

        if (useMaterialColor)
        {
            _renderer.material.color = ColorRandomizer(_renderer.material.color, hueVariation, saturationVariation, valueVariation);
        }
        else
        {
            _renderer.material.color = ColorRandomizer(baseColor, hueVariation, saturationVariation, valueVariation);
        }
    }


    public Color ColorRandomizer(Color originalColor, float hueVariation, float saturationVariation, float valueVariation)
    {
        //consigo el color en hsv
        Color.RGBToHSV(originalColor, out float originalHue, out float originalSaturation, out float originalValue);

        //randomizo el hsv teniendo en cuenta la variacion
        float newHue = Random.Range(originalHue - hueVariation, originalHue + hueVariation);
        float newSaturation = Random.Range(originalSaturation - saturationVariation, originalSaturation + saturationVariation);
        float newValue = Random.Range(originalValue - valueVariation, originalValue + valueVariation);

        //convierto y devuelvo
        Color resultColor = Color.HSVToRGB(newHue, newSaturation, newValue);
        return resultColor;
    }
}